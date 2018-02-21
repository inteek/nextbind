$(function () {
    debugger
    ObtenerGrupos(null,null,null,function (columnas) {
        debugger
        $('#jstree').jstree({
            core: {
                check_callback: true,
                data: columnas,
                multiple: false,
                cascade: "none",
                open_parents: true,
                load_open: true
            },
            plugins: ["search", "wholerow"]
        }).bind('click.jstree', function (e, data) {
            debugger
            var ElemSelected = $("#jstree").jstree(true).get_selected(true);
            if (ElemSelected[0].children == 0) {
                debugger
                var idparent = ElemSelected[0].id;
                var position = 'inside';
                var padre = ElemSelected[0].parent;
                ObtenerGrupos(ElemSelected, padre, idparent, function (columnas) {
                    debugger
                    if (columnas.length > 0) {
                        columnas.forEach(function (data) {
                            $('#jstree').jstree().create_node(idparent, data, position);
                        })
                    }
                });
            }
            else
            {
                $('#jstree').jstree().deselect_node(ElemSelected, false);
                $("#jstreeServicio").remove();
            }
        });

        var to = false;
        $('#treesearch').keyup(function () {
            if (to) { clearTimeout(to); }
            to = setTimeout(function () {
                var v = $('#treesearch').val();
                $('#jstree').jstree(true).search(v);
            }, 100);
        });
    });

});

function ObtenerGrupos(arbol,_padre, _id, callback)
{
    return $.ajax({
        url: urlGrupos,
        data: {
            id: _id,
            padre: _padre
        },
        dataType: "json",
        type: 'POST'
    }).done(function (data) {
        debugger;
        var array = $.map(data.list, function (item) {
            return {
                // adicional: false,
                id: item.descripcionGrupo,
                text: item.descripcionGrupo,
                icon: data.icon,
                state: {
                    opened: false,
                    selected: false,
                    disabled: false,
                },
                id_Grupo: item.idGrupo
                //children: true,
            }
        });
        callback(array)
    }).success(function () {
       $('#jstree').jstree().deselect_node(arbol, false);
       //$("#Siguiente").css("visibility", "hidden");
    }).fail(function () {
       // $("#Siguiente").css("visibility", "visible");
        CargarArbolTicket()
        //$("#Siguiente").disabled = false
    })
}

function ObtenerServicio(arbol,_padre, _id, callback) {
    debugger
    return $.ajax({
        url: urlPrueba,
        data: {
            id: _id,
            padre: _padre
        },
        dataType: "json",
        type: 'POST'
    }).done(function (data) {
        debugger;
        var array = $.map(data.list, function (item) {
            return {
                //parent: item.idServicioSuperior,
                id: item.descripcionServicio,
                text: item.descripcionServicio,
                icon: data.icon,
                state: {
                    opened: false,
                    selected: false,
                    disabled: false
                },
                children: false,
                id_Servicio: item.idServicio
            }
        });
        callback(array)
    }).success(function () {
        $('#jstreeServicio').jstree().deselect_node(arbol, false);
    }).fail(function () {
    });
}

function CargarArbolTicket()
{
    debugger
    $("#jstreeServicio").remove();
    $('#ContenedorArbol').append("<div id='jstreeServicio'></div>")
    var padre = $("#jstree").jstree(true).get_selected(true);
    ObtenerServicio(null,"#", padre[0].id, function (columnas) {
        debugger
        $('#jstreeServicio').jstree({
            core: {
                //adicional:false,
                check_callback: true,
                data: columnas,
                multiple: false,
                cascade: "none",
                open_parents: true,
                load_open: true
            },
            plugins: ["search", "wholerow"]
        }).bind('click.jstree', function (e, data) {
            debugger
            var ElemSelected = $("#jstreeServicio").jstree(true).get_selected(true);
            //var children = ElemSelected[0].children;
            if (ElemSelected[0].children == 0) {
                debugger
                var idparent = ElemSelected[0].id;
                var position = 'inside';
                ObtenerServicio(ElemSelected,"1", idparent, function (columnas) {
                    debugger
                    if (columnas.length > 0) {
                        columnas.forEach(function (data) {
                            $('#jstreeServicio').jstree().create_node(idparent, data, position);
                        })
                    }
                });
            }
            else
            {
                $('#jstreeServicio').jstree().deselect_node(ElemSelected, false);
            }
        });

        var to = false;
        $('#treesearchServicio').keyup(function () {
            if (to) { clearTimeout(to); }
            to = setTimeout(function () {
                var v = $('#treesearchServicio').val();
                $('#jstreeServicio').jstree(true).search(v);
            }, 100);
        });
    });
}

function ObtenerNoTicket(callback) {
    debugger
    return $.ajax({
        url: urlTicket,
        type: 'POST'
    }).done(function (data) {
        callback(data)
    })
}

function Agregar()
{
    debugger
    $("#txtAsunto2").val($("#txtAsunto").val())
    $("#txtDescripcion2").val($("#txtDescripcion").val())
    ObtenerNoTicket(function (datos) {
        if(datos.error == false)
        {
            //$("#txtNoTicket").val(datos.id);
            $("#txtNoTicket").text(datos.id);
        }
        else
        {
            alert(datos.msg)
        }
    });
}

function Registrar(callback) {
    debugger
    return $.ajax({
        url: urlRegistro,
        type: 'POST'
    }).done(function (data) {
        callback(data)
    })
}

function RegistrarTicket()
{
    debugger
    var _asunto = $("#txtAsunto2").val()
    var _descripcion = $("#txtDescripcion2").val()
    var ElemSelected = $("#jstree").jstree(true).get_selected(true)
    var _grupo = ElemSelected[0].original.id_Grupo;
    ElemSelected = $("#jstreeServicio").jstree(true).get_selected(true)
    var _tipoServicio = ElemSelected[0].original.id_Servicio
    var idUsuarioLevanta = "alfredo"

    return $.ajax({
        url: urlRegistro,
        data: {
            titulo: _asunto,
            desc: _descripcion,
            tipo_Servicio: _tipoServicio,
            id_Area: _grupo,
            idEstatus: 1,
            ruta: null
        },
        dataType: "json",
        type: 'POST',  
    }).success(function (data) {
        alert(data.msg)
    })
}