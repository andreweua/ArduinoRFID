
google.load('visualization', '1.0', { 'packages': ['corechart', 'table'] });
google.load("visualization", "1", { packages: ["corechart"] });

var map = null;

$(document).ready(function () {
    initialize();
});

function initialize() {

    $("#chart_ativos").html("<img src ='/Images/loadingAnimation.gif'>");
    $("#chart_percentual").html("<img src ='/Images/loadingAnimation.gif'>");
    $("#chart_ultimosacessos").html("<img src ='/Images/loadingAnimation.gif'>");


    CountPontos = 0;
    if (GBrowserIsCompatible()) {
        map = new GMap2(document.getElementById("mapa"));
        map.setCenter(new GLatLng(-23.550734, -46.634978), 13);
        var ui = new GMapUIOptions();
        ui.maptypes = { normal: true };
        ui.zoom = { doubleclick: true, scrollwheel: true };
        ui.controls = { largemapcontrol3d: true, scalecontrol: true, draggable: false };
        ui.keyboard = false;

        map.setUI(ui);
        map.addControl(new GOverviewMapControl(new GSize(100, 100)));

        GetAcessos();

    }

    GetColaboradoresAtivos();
    GetPercentualColaboradoresAcesso();
    GetUltimosAcessos();

}

function GetAcessos() {

    $.ajax({
        url: "DashBoard/GetMapaAcessos",
        type: "GET",
        error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); },
        success: function (data) {
            if (data != '') {
                $(data).each(function () {
                    BindAcesso(this);
                });
            }
            else {
            }
        }
    });
}

function BindAcesso(acesso) {

    var Documento = acesso.Documento;
    var Nome = acesso.Nome;
    var Email = acesso.Email;
    var Foto = acesso.Foto;
    var DataAcesso = acesso.DataAcesso;

    var Local = acesso.Local;
    var Latitude = acesso.Latitude;
    var Longitude = acesso.Longitude;
    var Movimento = acesso.Movimento;

    var Texto = "Local: " + Local + "<BR>Colaborador: " + Nome + "<BR> Horário: " + DataAcesso;


    var Icon = new GIcon(G_DEFAULT_ICON);
    Icon.image = "Images/" + Foto;
    Icon.iconSize = new GSize(60, 60);

    var markerOptions = { icon: Icon, text: "Hello! I'm a PopupMarker." };


    var point = new GLatLng(Latitude, Longitude);
    map.addOverlay(new GMarker(point, markerOptions));

}


function GetColaboradoresAtivos() {

    $.ajax({
        url: "DashBoard/GetColaboradoresAtivos",
        type: "GET",
        error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); },
        success: function (data) {
            if (data != '') {
                LoadColaboradoresAtivos(data)
            }
            else {
                $("#chart_ativos").html("<p>Nenhum colaborador ativo!</p>");
            }
        }
    });
}


function LoadColaboradoresAtivos(dados) {

    var matrix = new Array();
    var param = new Array();
    var array = new Array();


    $(dados).each(function () {

        var dataformatada = new Date(parseInt(this.Data.substr(6)));

        param = new Array();
        param[0] = this.Nome;
        param[1] = this.Local;
        param[2] = dataformatada;
        matrix.push(param);

    });


    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Nome');
    data.addColumn('string', 'Local');
    data.addColumn('date', 'Data');

    data.addRows(matrix);

    var table = new google.visualization.Table(document.getElementById('chart_ativos'));

    table.draw(data, { showRowNumber: false });
    //table.draw(data, { showRowNumber: true, page: 'enable', pageSize: 10 });

}


function GetPercentualColaboradoresAcesso() {

    $.ajax({
        url: "DashBoard/GetPercentualColaboradoresAcesso",
        type: "GET",
        error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); },
        success: function (data) {
            LoadPercentualColaboradoresAcesso(data)
        }
    });
}


function LoadPercentualColaboradoresAcesso(dados) {

    var data = google.visualization.arrayToDataTable([
                    ['Task', 'Hours per Day'],
                    ['Ativos', dados.Acesso],
                    ['Inativos', dados.NaoAcesso]
                  ]);


    var options = {
        title: '',
        height: 200,
        width: 500
    };

    var chart = new google.visualization.PieChart(document.getElementById('chart_percentual'));
    chart.draw(data, options);

}



function GetUltimosAcessos() {
    $.ajax({
        url: "DashBoard/GetUltimosAcessos",
        type: "GET",
        error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); },
        success: function (data) {
            if (data != '') {
                LoadUltimosAcessos(data)
            }
            else {
                $("#chart_ultimosacessos").html("<p>Nenhum acesso!</p>");
            }
        }
    });
}


function LoadUltimosAcessos(dados) {


    var matrix = new Array();
    var param = new Array();
    var array = new Array();


    $(dados).each(function () {

        var dataformatada = new Date(parseInt(this.Data.substr(6)));

        param = new Array();
        param[0] = this.LocalViewModel.Nome;
        param[1] = this.ColaboradorViewModel.Nome;
        param[2] = this.MovimentoFormatado;
        param[3] = dataformatada;
        matrix.push(param);

    });

    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Local');
    data.addColumn('string', 'Nome');
    data.addColumn('string', 'Movimento');
    data.addColumn('date', 'Data');

    data.addRows(matrix);

    var table = new google.visualization.Table(document.getElementById('chart_ultimosacessos'));

    table.draw(data, { showRowNumber: false });

}