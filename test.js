'use strict';
var fnMantenedor = function () {
    let local = {}, model = {};
    let urls = {
        save: 'Maestro/PersonaGuardar',
        list: 'Maestro/ListarPersona',
        get: 'Maestro/ObtenerPersona',
        delete: 'Maestro/EliminarPersona',
    };
    let dom = {
        $tabla: null,
        $dvTabla: $('#dvTabla'),

        $txtCodigo: $('#txtCodigo'),
        $txtPrimerNombre: $('#txtPrimerNombre'),
        $txtSegundoNombre: $('#txtSegundoNombre'),
        $txtApellidoPaterno: $('#txtApellidoPaterno'),
        $txtApellidoMaterno: $('#txtApellidoMaterno'),
        $txtNroIdentidad: $('#txtNroIdentidad'),
        $cboTipoIdentidad: $('#cboTipoIdentidad'),

        $txtTitulo: $('#txtTitulo'),

        $txtDireccion: $('#txtDireccion'),
        $txtEmail: $('#txtEmail'),
        $txtTelefono: $('#txtTelefono'),
        $txtCelular: $('#txtCelular'),
         
        $txtGerencia: $('#txtGerencia'),
        $txtArea: $('#txtArea'),
        $txtUbigeo: $('#txtUbigeo'),
        $txtPais: $('#txtPais'),
        $txtDistrito: $('#txtDistrito'),
        $txtCargo: $('#txtCargo')
    };
    let frm = {
        name: "#frm-mantenedor",
        state: fnEnums.StateForm.Invalid,
        message: '',
        validate: function () {
            init_validate({
                form: frm.name,
                rules: {
                    Codigo: 'required',
                    Titulo: 'required',
                    NroIdentidad: 'required',
                    TipoIdentidad: 'required',
                    PrimerNombre: 'required', 
                    ApellidoPaterno: 'required',
                    ApellidoMaterno: 'required',
                    Direccion: 'required',
                    Email: { 
                        required: true,
                        email : true
                    },
                    Telefono: {
                        required: true, 
                        pattern: '(((\+) ? ([0 - 9] | -)[0 - 9])| ((\+)?([0 - 9] | )[0 - 9]))'
                    },
                    Celular: {
                        required: true,
                        pattern: "/^\S*$/"
                    },
                    Area: 'required',
                    Ubigeo: 'required',
                    Pais: 'required' 
                }
            })
        },
        valid: function () {
            frm.message = "";
            if (!(dom.$cboEquipo.val() > 0))
                frm.message += "Ingrese un nombre \r\n";
            if (!(dom.$txtAnio.val()) > 0)
                frm.message += "Ingrese un nombre  \r\n";
            if (!(dom.$cboMarca.val()) > 0)
                frm.message += "Ingrese un nombre \r\n";
            if (!(dom.$cboModelo.val()) > 0)
                frm.message += "Ingrese un nombre  \r\n";
            if (!(dom.$cboTipoTrabajo.val()) > 0)
                frm.message += "Seleccione un tipo de Trabajo \r\n";
            if (!(dom.posesion.$ValorAdquisicion.val() > 0))
                frm.message += "Ingrese el Valor de Adquisición (Va) \r\n";
            if (!(dom.posesion.$VidaEconomicaUtil.val() > 0))
                frm.message += "Ingrese la Vida Económica Útil (VEU) \r\n";
            if (!(dom.posesion.$ValorRescate.val() > 0))
                frm.message += "Ingrese el Valor de Rescate (Vr) \r\n";
            if (!(dom.posesion.$TasaInteres.val() > 0))
                frm.message += "Ingrese el TAMN / TAMEX \r\n";
            if (!(dom.operacion.$ConsumoPromedio.val() > 0))
                frm.message += "Ingrese Consumo Promedio de Combustible\r\n";
            if (!(dom.operacion.$CostoxGalon.val() > 0))
                frm.message += "Ingrese Costo por Galón de Combustible\r\n";
            if (!(dom.operacion.$CostoLubricantes.val() > 0))
                frm.message += "Ingrese Costo de Lubricantes \r\n";
            if (!(dom.operacion.$CostoGrasas.val() > 0))
                frm.message += "Ingrese Costo de Grasas \r\n";
            if (!(dom.operacion.$CostoFiltros.val() > 0))
                frm.message += "Ingrese Costo de Filtros \r\n";
            if (frm.message === "")
                frm.status = fnEnums.StateForm.Valid;
            else frm.status = fnEnums.StateForm.Invalid;
            return frm.status === fnEnums.StateForm.Valid;
        },
        get: function () {
            model.Codigo = dom.$cboEquipo.val();
            model.Nombre = dom.$txtAnio.val();
            model.SegundoNombre = dom.$cboMarca.val();
            model.ApellidoPaterno = dom.$cboModelo.val();
            model.ApellidoMaterno = dom.$txtPotencia.val();
            model.Titulo = dom.$cboTipoTrabajo.val();
            model.Direccion = dom.$txtCostoAlimentacion.val();
            model.CodigoCiudad = dom.$txtNroDiasMes.val();
            model.Ubigeo = dom.$txtNroAlimentacionDia.val();
            model.Pais = dom.$txtCostoExamenIngreso.val();
            model.Telefono = dom.$txtCostoExamenFinal.val();
            model.Email = dom.$txtNroHorasMes.val();
            model.Extension = dom.$txtFactorEPP.val();
            model.Celular = dom.$cboMoneda.val();
            model.Area = dom.$cboMoneda.val();
            model.Gerencia = dom.$cboMoneda.val();
            model.Distrito = dom.$cboMoneda.val();
            model.Cargo = dom.$cboMoneda.val();
            return model;
        },
        load: function (data) {
            dom.$txtCodigo.val(model.Codigo);
            dom.$txtPrimerNombre.val(model.Nombre);
            dom.$txtSegundoNombre.val(model.SegundoNombre);
            dom.$txtApellidoPaterno.val(model.ApellidoPaterno);
            dom.$txtApellidoMaterno.val(model.ApellidoMaterno);
            dom.$txtTitulo.val(model.Titulo);
            dom.$txtDireccion.val(model.Direccion);
            dom.$cboCodigoCiudad.val(model.CodigoCiudad);
            dom.$txtUbigeo.val(model.Ubigeo);
            dom.$chkPais.val(model.Pais);
            dom.$txtTelefono.val(model.Telefono);
            dom.$txtEmail.val(model.Email);
            dom.$txtExtesion.val(model.Extension);
            dom.$txtCelular.val(model.Celular);
            dom.$txtArea.val(model.Area);
            dom.$cboGerencia.val(model.Gerencia);
            dom.$cboDistrito.val(model.Distrito);
            dom.$txtCargo.val(model.Cargo);
        },
        clear: function () {
            model = {};
            clearValidate(frm.name);
            frm.load({});
            EnableDom(dom.$cboEquipo);
            events.loadEquipo();
            events.loadMarca();
        }
    };
    let events = {
        init: function () {
            $("#btnGuardar").click(events.save);

            $("#btnRegresar").click(events.return);
            $("#btnNuevo").click(events.new);
             
        },
        edit: function (id) {
            fnAjax({
                url: urls.get,
                data: { Id: id },
                success: function (result) {
                    frm.load(result.data);
                }
            });
        },
        save: function () {
            var _btn = $(this);
            if (!frm.valid()) { EnableDom(_btn); fnNotification.Show(fnEnums.Status.Warning, frm.message, "¡Advertencia!"); return; }
            //fnNotification.Confirm(fnEnums.Actions.Warning, "Advertencia!", "Se generará una nueva version de Costo Horario", function () {
            //    DisableDom(_btn);
            //    fnAjax({
            //        url: urls.save,
            //        data: frm.get(),
            //        success: function (result) {
            //            EnableDom(_btn);
            //            fnNotification.Show(result.status, result.message);
            //            if (result.status === fnEnums.Status.Success)
            //                events.return();
            //                //events.loadVersion();
            //        },
            //        error: function (result) {
            //            EnableDom(_btn);
            //        }
            //    });
            //});
        },
        delete: function () {
            var data = dom.$tree.tree("getSelected");
            fnNotification.Confirm(fnEnums.Actions.Remove, "Advertencia!", "¿Está seguro que desea eliminar el registro?", function () {
                fnAjax({
                    url: urls.delete, data: { Codigo: data.Codigo }, success: function (result) {
                        if (result.status === fnEnums.Status.Success) {
                            events.reloadNode();
                        }
                        fnNotification.Show(result.status, result.message);
                    }
                });
            });
        },
        list: function () {
            var columns = [
                {
                    data: null,
                    render: function (data, type, row, meta) {
                        return meta.row + meta.settings._iDisplayStart + 1;
                    }
                },
                { data: 'Codigo' },
                { data: 'TituloDescripcion', class: 'align-center' },
                { data: 'NombreCompleto' }, 
                { data: 'TipoIdentidad', class: 'align-center' },
                { data: 'NroIdentidad', class: 'align-center' },
                { data: 'Direccion', class: 'align-center' },
                { data: 'Pais', class: 'align-center' },
                { data: 'Ciudad', class: 'align-center' },
                { data: 'Ubigeo', class: 'align-center' },
                { data: 'Email', class: 'align-center' },
                { data: 'Telefono', class: 'align-center' },
                { data: 'Extension', class: 'align-center' },
                { data: 'Celular', class: 'align-center' },
                { data: 'Area', class: 'align-center' },
                { data: 'Gerencia', class: 'align-center' },
                { data: 'DistritoEmpresa', class: 'align-center' },
                { data: 'Cargo', class: 'align-center' }
            ];
            var buttons = [
                {
                    name: 'Editar',
                    primary: true,
                    onclick: events.view,
                    tooltip: { title: 'Editar' },
                    iconClass: "fa fa-pencil-alt font-18"
                },

                {
                    name: 'Eliminar',
                    primary: true,
                    onclick: events.delete,
                    tooltip: { title: 'Eliminar' },
                    iconClass: "fa fa-pencil-alt font-18"
                } 
            ]
            var params = {

            };
            dom.$tabla = fnDTable({
                id: "#tabla-mantenedor"
                , url: urls.list
                , columns: columns
                , buttons: buttons
                , params: params
                , server: false
                , search: false
            });
        },
        view: function (data) {
            dom.$dvTabla.fadeOut(400, function () {
                dom.$dvNuevo.fadeIn();
                $("#btnGuardar").addClass("hidden");
                events.edit(data.IdPersona);
            });
        },
        new: function () {
            dom.$dvTabla.fadeOut(400, function () {
                dom.$dvNuevo.fadeIn();
                $("#btnGuardar").removeClass("hidden");
                frm.clear();
            });
        },
        return: function () {
            dom.$dvNuevo.fadeOut(400, function () {
                dom.$dvTabla.fadeIn();
                events.list();
            });
        }
    };
    return {
        init: function () {
            frm.validate();
            events.init();
            events.list();
        },
    };
}();
$(function () {
    fnMantenedor.init();
});
