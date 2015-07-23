
// Criado por Alex(sandro) S Pimenta 2009, July

// Define funcionalidade do botão Ok do dialog
var sFuncaoAlert = "$(this).dialog('close');";
var sFuncaoConfirm = ""; // ex: __doPostBack('< % = Control.ClientID  % >', '')
var sFuncaoYesNo = ""; // ex: __doPostBack('< % = Control.ClientID  % >', '')

var PosX = 0;
var PosY = 0;

// Inicializa Diálogo
$(document).ready(function() {

    var divTag = document.createElement("div");
    divTag.id = "dialogAlert";
    document.body.appendChild(divTag);

    var divTag = document.createElement("div");
    divTag.id = "dialogConfirm";
    document.body.appendChild(divTag);

    var divTag = document.createElement("div");
    divTag.id = "dialogYesNo";
    document.body.appendChild(divTag);

    $("#dialogAlert").dialog({
        autoOpen: false,
        bgiframe: false,
        modal: true,
        overlay: {
            backgroundColor: '#000',
            opacity: 0.5
        },
        resizable: false,
        buttons: {
            Ok: function() {
                eval(sFuncaoAlert);
            }
        }
    });

    $("#dialogConfirm").dialog({
        autoOpen: false,
        bgiframe: true,
        resizable: false,
        height: 160,
        width: 350,
        modal: true,
        overlay: {
            backgroundColor: '#000',
            opacity: 0.8
        },
        buttons: {
            'Excluir': function() {
                $(this).dialog('close');
                eval(sFuncaoConfirm);
            },
            'Cancelar': function() {
                $(this).dialog('close');
            }
        }
    });

    $("#dialogYesNo").dialog({
        autoOpen: false,
        bgiframe: true,
        resizable: false,
        height: 160,
        width: 350,
        modal: true,
        overlay: {
            backgroundColor: '#000',
            opacity: 0.8
        },
        buttons: {
            'Sim': function() {
                $(this).dialog('close');
                eval(sFuncaoYesNo);
            },
            'Não': function() {
                $(this).dialog('close');
            }
        }
    });

});

// Mostra um Modal Dialog, com a mensagem e título, atuando como um alert();
function showJQueryAlert() {
    if (arguments.length < 2) return;
    document.getElementById("dialogAlert").title = arguments[1].toString();
    document.getElementById("dialogAlert").innerHTML = arguments[0].toString();
    $('#dialogAlert').dialog('option', 'title', (arguments[1].toString().trim().length > 0 ? arguments[1] : "Confirmação"));
    $('#dialogAlert').dialog('option', 'hide', 'slide');
    $('#dialogAlert').dialog('option', 'show', 'slide');
    if (arguments.length == 3) sFuncaoAlert = arguments[2].toString();
    else sFuncaoAlert = "$(this).dialog('close');";  // Fecha a caixa de diálogo am clicar em Ok.
    $('#dialogAlert').dialog("open");
}

function showJQueryConfirm() {
    var sMessage = '<p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>' + arguments[0] + '</p>';
    document.getElementById("dialogConfirm").innerHTML = sMessage;
    $('#dialogConfirm').dialog('option', 'title', (arguments[1].toString().trim().length > 0 ? arguments[1] : "Confirmação"));
    $('#dialogConfirm').dialog('option', 'hide', 'slide');
    $('#dialogConfirm').dialog('option', 'show', 'slide');
    if (arguments.length == 3) sFuncaoConfirm = arguments[2].toString();
    else sFuncaoConfirm = "";
    $('#dialogConfirm').dialog("open");
    return false;
}

function showJQueryYesNo() {
    var sMessage = '<p><span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span>' + arguments[0] + '</p>';
    document.getElementById("dialogYesNo").innerHTML = sMessage;
    $('#dialogYesNo').dialog('option', 'title', (arguments[1].toString().trim().length > 0 ? arguments[1] : "Confirmação"));
    $('#dialogYesNo').dialog('option', 'hide', 'slide');
    $('#dialogYesNo').dialog('option', 'show', 'slide');
    if (arguments.length == 3) sFuncaoYesNo = arguments[2].toString();
    else sFuncaoYesNo = "";
    $('#dialogYesNo').dialog("open");
    return false;
}

function confirmDelete() {
    showJQueryConfirm("Todos os ítens selecionados serão excluídos. Tem certeza?", "Excluir?");
    return false;
}

function AccordionChangeEnableState() {
    if (arguments.length < 2) return;
    jQuery('#' + arguments[0]).attr("disabled", (arguments[1].toLowerCase() == "true" ? "disabled" : ""));
    jQuery('#' + arguments[0] + " a:first").attr("disabled", (arguments[1].toLowerCase() == "true" ? "disabled" : ""));
    jQuery('#' + arguments[0]).parent().accordion("activate", false);
}
