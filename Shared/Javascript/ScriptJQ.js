/**
* Inicializa as funções assim que os elementos (DOM) são carregados
@author Douglas Rodrigues <douglas.rodrigues@gommo.com.br>
*/
jQuery(function() {
    /*Project._init();*/

    jQuery(function() {
        jQuery('.tableConsultas tbody tr').mouseover(function() {
            jQuery(this).addClass('bgTableHover');
        }).mouseout(function() {
            jQuery(this).removeClass('bgTableHover');
        });
    });
});

jQuery(function() {
    jQuery('.linkExibir a').click(function() {
        jQuery('.fieldsetFiltragem').slideToggle();
        return false;
    });
});


jQuery(function() {
    jQuery(".navTabs a").click(function() {
        jQuery("div.navegacaoAbas").hide();
        jQuery(".navTabs a").removeClass("selected");
        jQuery(this).addClass("selected");
        jQuery(jQuery(this).attr("href")).show();
        return false;
    });
});

function openModalHistorico(paramTitulo, paramHeight, paramWidth) {

    var modalBasic = "<div id='modalTitulo'>" + paramTitulo + "</div>";

    var url = "";
    var modalHeight = 400;
    var modalWidth = 600;

    if (paramWidth > 0) {
        modalWidth = paramWidth
    }

    if (paramHeight > 0) {
        modalHeight = paramHeight;
    }

    var modalInternoHeight = modalHeight - 50;
    var modalInternoWidth = modalWidth - 20;

    modalBasic += "<div id='modalContent' style='height: " + modalInternoHeight + "; width: " + modalInternoWidth + "; overflow: auto;'>teste</div>";

    $.modal(modalBasic, {
        minHeight: modalHeight, maxHeight: modalHeight,
        minWidth: modalWidth, maxWidth: modalWidth
    });

    $("#modalContent").load("loading/modal.html");

    $.ajaxSetup({ cache: false });

    $.ajaxSetup({ cache: true });

}

var Project = {
    /**
    * Função de chamada das outras funções que inicializam o site
    * @author Douglas Rodrigues <douglas.rodrigues@gommo.com.br>
    * @modified 
    */
    _init: function() {
        try {
            Project._pngFix();
            Project._externalLink();
            Project._flash();
        } catch (e) {
            var initial_e = e;
            try {
                console.log('Error: ' + initial_e.description);
            } catch (e) {
                alert('Error: ' + initial_e.description);
            }
        }
    },

    /**
    * Ativa pngfix
    * @author Douglas Rodrigues <douglas.rodrigues@gommo.com.br>
    * @modified 
    */
    _pngFix: function() {
        //Apenas IE 6, se apenas um elemento MSIE for encontrado e conter o valor 6
        if (!/msie [^6]\.0/i.test(navigator.userAgent) && /msie 6\.0/i.test(navigator.userAgent)) {
            DD_belatedPNG.fix('img, .pngfix');
        };
    },

    /**
    * target blank
    * @author Douglas Rodrigues <douglas.rodrigues@gommo.com.br>
    */
    _externalLink: function() {
        $('a[rel="external-link"]').click(function() {
            $(this).attr('target', '_blank');
        });
    },

    /**
    * carrega flash
    * @author Douglas Rodrigues <douglas.rodrigues@gommo.com.br>
    */
    _flash: function() {
        var params = { allowScriptAccess: "always", wmode: "transparent" };
        swfobject.embedSWF("/path/teste.swf", "teste", "275", "134", "8", null, null, params, "teste");
    }

};