
var data_Tickets
var datos;

$(document).ready(function () {
    debugger

    datos = conectarAsy(ruta, null, function (result) {
        debugger
        if (result.error == false)
        {
            configurarGrid(result.list)

            var altura1 = document.getElementById('ContenedorInterno').offsetHeight
            var altura2 = document.getElementById('plegado').offsetHeight
            var newHeight = altura1 + altura2;
            $('#Contenedor').css('height', newHeight.toString() + "px");

            $(".btn.btn-primary.btn-xs").on("click", function (e) {
                debugger
                var div = document.getElementById('plegado');
                //if (div.className == "Yup") {
                //}
                if(div.className!="Yup"){
                    var top = e.pageY - 250;
                    $("#plegado").animate({
                        width: "30%",
                    }, 300);
                    div.className = "Yup"
                    $('#plegado').css("margin-top", top.toString() + "px");      
                }
            })
        }//Aqui se carga el grid
        else
            alert(result.msg)     
    })

    $('#Cerrar').on("click", function () {
        var div = document.getElementById('plegado');
        if (div.className == "Yup") {
            $("#plegado").animate({
                width: 0,
            })
            div.className = ""
        }
    })

    $('#CerrarDetalle').on("click", function () {
        var div = document.getElementById('plegado');
        if (div.className == "Yup") {
            $("#plegado").animate({
                width: 0,
            })
            div.className = ""
        }
    })

})

function configurarGrid(dataSet) {
    debugger

    if (data_Tickets != null) {
        data_Tickets.destroy();
    }
    data_Tickets = $('#tblTickets').DataTable({//hay que encontrar un metodo que refresque la tabla 
        //"scrollY": '300px',
        //"scrollX": true,
        "paging": true,
        "searching": false,
        "pagingType": "simple_numbers",
        "autoWidth": false,
        "width":"100%",
        "info": false,
        "bLengthChange": false,
        "dom": '<"bottom"i>rt<"top"flp><"bottom">',
        language: {
            emptyTable: "",
            loadingRecords: "",
            zeroRecords: ""
        },
        data: dataSet,
        columns: [
             { title: "Asunto", data: "Titulo_ticket" },
                { title: "Descripcion", data: "Descripcion_ticket" },
                { title: "Tipo Servicio", data: "Tipo_de_servicio" },
                { title: "Area", data: "Grupo" },
                { title: "Asignado", data: "Usuario_Asignado" },
                { title: "Fecha", data: "Fecha" },
                {title: "Asignar", defaultContent: "<button type='button' class='btn btn-primary btn-xs'>Asignar</button>"}
        ],
      //  columnDefs: [
      //  {
      //"targets": 0,
      //"data": null,
      //"defaultContent": '<a class="linkEdit busqcli2" data-id="2">Editar</a>'
      //  }
        //],
        "language": {
            "sZeroRecords": "No se encontraron resultados",
            //"oPaginate": {
            //    "sFirst": "Primero",
            //    "sLast": "Último",
            //    "sNext": "Siguiente",
            //    "sPrevious": "Anterior"
            //}
        }
    });
}

