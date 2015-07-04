using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace InnerSoft.MeEncontre.Domain.Model
{
    public class Acesso
    {
        [Key()]
        public int Id { get; set; }
        public string LocalKey { get; set; }
        public string ColaboradorKey { get; set; }
        public virtual Local Local { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public DateTime Data { get; set; }
        public String Movimento { get; set; }
        public Cliente Cliente { get; set; }


        public void AtualizaUltimoMovimento(Acesso ultimoAcesso)
        {
            if (ultimoAcesso != null && ultimoAcesso.Movimento == "E")
                Movimento = "S";
            else
                Movimento = "E";

        }

        public string RetornaAcesso()
        {
            string retorno = String.Empty;
            string nome = Colaborador.Nome;
            if (nome.Length>20)
                 nome = nome.Substring(0, 20);
            else if (nome.Length<20)
                nome = nome.PadRight(20, ' ');

            retorno = String.Format("|{0}{1}|", Movimento, nome);

            return retorno;
        }    

    }

}
