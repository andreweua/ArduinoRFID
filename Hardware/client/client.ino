/*

Me Encontre
Sergio de Miranda e Castro Mokshin
26/04/2013
 
*/

#include <SPI.h>
#include <Ethernet.h>
#include <LiquidCrystal.h>

#define PIN_SAIDA_BUZZ 49

byte mac[] = { 
  0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED};
// assign an IP address for the controller:
byte ip[] = { 
  192,169,1,20 };
byte gateway[] = {
  192,168,1,1};	
byte subnet[] = { 
  255, 255, 255, 0 };

byte server[] = {  74, 86, 188 ,173 }; 

char serverName[] = "api.meencontre.com.br.m6.net"; 
EthernetClient client;

char tagRFID[10];
boolean lastConnected = false;

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
int rele1 = 22;
char validacaoTag;
char nomeTag[20];
int indexretornoServer;
boolean inicioretornoServer;

int KEY1 = 26;
int KEY2 = 28;
int KEY3 = 30;
int KEY4 = 32;
int localKEY1 = 0;
int localKEY2 = 0;
int localKEY3 = 0;
int localKEY4 = 0;


void setup() {
  
  pinMode(rele1, OUTPUT);  
  digitalWrite(rele1, HIGH); 

//  pinMode(KEY1, INPUT);
//  pinMode(KEY2, INPUT);
//  pinMode(KEY3, INPUT);
//  pinMode(KEY4, INPUT);
    
  indexretornoServer = 0;
  inicioretornoServer = false;
  
  lcd.begin(20, 4);
  lcd.print("Me Encontre         ");
  lcd.setCursor(0, 1);
  lcd.print("                    ");
  lcd.setCursor(0, 2);
  lcd.print("Iniciando Sistema   ");
  
  Serial.begin(9600);
  delay(1000);
  Serial.println("connecting...");
  
   if (Ethernet.begin(mac) == 0) {
    Serial.println("Failed to configure Ethernet using DHCP");
    while(true);
  }
  
  aguardandocomandos();    
  
}


void loop()
{    
  chavelocal();  
  verificacartao();  
  lastConnected = client.connected();   
}

void chavelocal(){
  
  localKEY1 = digitalRead(KEY1);
  localKEY2 = digitalRead(KEY2);
  localKEY3 = digitalRead(KEY3);
  localKEY4 = digitalRead(KEY4);
  
  Serial.print(localKEY1);   
  Serial.print(localKEY2);   
  Serial.print(localKEY3);     
  Serial.println(localKEY4);   
   
}

void verificacartao(){
  
  byte i = 0;
  byte val = 0;
  byte code[6];
  byte checksum = 0;
  byte bytesread = 0;
  byte tempbyte = 0;
   
  if(Serial.available() > 0) {      
    if((val = Serial.read()) == 2) { 
      bytesread = 0; 
      while (bytesread < 12) {     
        if( Serial.available() > 0) { 
          
          lcd.setCursor(0, 1);
          lcd.print("                   ");
          lcd.setCursor(0, 2);
          lcd.print("Buscando Dados     ");
          lcd.setCursor(0, 3);
          lcd.print("                   ");
            
          val = Serial.read();          
          if (bytesread < 10)
          {
            tagRFID[bytesread] = val;
          }
                    
          if((val == 0x0D)||(val == 0x0A)||(val == 0x03)||(val == 0x02)) { 
            break;   
          }
   
          if ((val >= '0') && (val <= '9')) {
            val = val - '0';
          } else if ((val >= 'A') && (val <= 'F')) {
            val = 10 + val - 'A';
          }
          
          if (bytesread & 1 == 1) {
            code[bytesread >> 1] = (val | (tempbyte << 4));
            if (bytesread >> 1 != 5) {               
              checksum ^= code[bytesread >> 1];      
            };
          } else {
            tempbyte = val;                          
          };

          bytesread++;                               
        } 
      } 

      if (bytesread == 12) {
        tagRFID[10] = '\0';
        validaAcesso();
      }            
      bytesread = 0;
    }
  }

  
}

void validaAcesso() 
{
  Serial.println(tagRFID);
  if (client.connect(serverName, 80)) {
    Serial.println("connected");
    client.print("GET /api/acesso/INNER/0001/");
    client.print(tagRFID); 
    client.println(" HTTP/1.0");
    client.println("Host: api.meencontre.com.br.m6.net");
    client.println(); 
  } 
  else {
    Serial.println("connection failed");
    Serial.println();
    lcd.setCursor(0, 1);

    lcd.print("Erro durante acesso ");
    lcd.setCursor(0, 2);
    lcd.print("Tente novamente     ");

  }

  inicioretornoServer = false;
  indexretornoServer = 0;
  
  while(client.connected() && !client.available()) delay(1); //waits for data
  while (client.connected() || client.available()) { //connected or data available
    char c = client.read(); //gets byte from ethernet buffer
    Serial.print(c);
    if (c == '|')
    {
      inicioretornoServer = !inicioretornoServer;
      indexretornoServer = 0;
    }
    
    if (inicioretornoServer)
    {    
      //Serial.println(indexretornoServer);          
      //Serial.println(c); //prints byte to serial monitor 
      if(indexretornoServer == 1)
      {
            validacaoTag = c;            
      }
      else if(indexretornoServer >= 2 && indexretornoServer <= 22)      
      {
          nomeTag[indexretornoServer-2] = c;            
      }      
      indexretornoServer++;
      //Serial.println(indexretornoServer);          
    }  
  }

 
  Serial.println(" ");    
  Serial.print("Validacao: ");    
  Serial.print(validacaoTag);    
  Serial.println(" ");    
  Serial.print("Nome: ");    
  Serial.print(nomeTag);    
  
  lcd.setCursor(0, 1);
  lcd.print("                    ");
  lcd.setCursor(0, 2);
  lcd.print(nomeTag);
  lcd.setCursor(0, 3);

  if(validacaoTag == 'E'){
    digitalWrite(rele1, LOW);
    lcd.print("Entrada Registrada  ");}    
    
  if(validacaoTag == 'S'){
    digitalWrite(rele1, LOW);    
    lcd.print("Saida Registrada    ");}
 
   if(validacaoTag == 'X'){
    lcd.print("Cartao sem Acesso   ");}   

  Serial.println();
  Serial.println("disconnecting.");
  Serial.println("==================");
  Serial.println();


  delay(1000);  
  digitalWrite(rele1, HIGH);
  delay(500);  
  client.stop(); //stop client
  aguardandocomandos();  
}


void consultacartaoserver(){
   
  lcd.setCursor(0, 1);
  lcd.print("Consultando dados   ");   
  lcd.setCursor(0, 2);
  lcd.print("      Aguarde       ");   
    
  Serial.print("Cartao: ");
  Serial.println(tagRFID); 
  
  
  int thisData;
  thisData = 12234;


  
}

void aguardandocomandos(){
  lcd.setCursor(0, 1);
  lcd.print("                    ");
  lcd.setCursor(0, 2);
  lcd.print("Passe o Cartao      ");   
  lcd.setCursor(0, 3);
  lcd.print("                    ");


}





