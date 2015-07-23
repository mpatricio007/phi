/*
	Empresa			: Gommo

	Autor			: Claudio Paulo de Oliveira
	Data/Criação	: 07/05/2009
	Data/Alteração	: 07/05/2009
 
	Produto			: Gommo Template WebBased
	JScript			: Loading.js
	Descrição		: JavaScript com funções p/ loading de PostBack's.
*/
	// InitializeRequest function
	function InitializeRequest() {	
		try {
			var prm = Sys.WebForms.PageRequestManager.getInstance();
			var postBackElement;

			for (var n = 0 ; n < document.getElementsByTagName('SELECT').length; n++) {
				try {
					document.getElementsByTagName('SELECT')[n].style.visibility = 'hidden';
				} catch (e) {
				}
			}

			// BeginRequest function
			function BeginRequest () {
				try {
					for (var n = 0 ; n < document.getElementsByTagName('SELECT').length; n++) {
						try {
							document.getElementsByTagName('SELECT')[n].style.visibility = 'hidden';
						} catch (e) {
						}
					}
				
					setLoadingPosition();
					document.getElementById('updLoading').style.display = "block";
					document.getElementById('updBackground').style.display = "block";
				} catch (e) {
				}
			}

			// EndRequest function
			function EndRequest () {
				try {
					for (var n = 0 ; n < document.getElementsByTagName('SELECT').length; n++) {
						try {
							document.getElementsByTagName('SELECT')[n].style.visibility = (document.getElementById('lblMessage').innerHTML == "" ? "visible" : "hidden");
						} catch (e) {
						}
					}
					
					document.getElementById('updLoading').style.display = "none";
					document.getElementById('updBackground').style.display = "none";
					document.getElementById('updBackground').style.display = (document.getElementById('lblMessage').innerHTML == "" ? "none" : "block");
				} catch (e) {
				}
			}

			// InitializeRequest function
			function InitializeRequest(sender, args) {
				if (prm.get_isInAsyncPostBack()) {
					args.set_cancel(true);
				}

				postBackElement = args.get_postBackElement();

				if (typeof(postBackElement) != 'undefined') {
					BeginRequest();
				}
			}

			prm.add_initializeRequest(InitializeRequest);
			prm.add_beginRequest(BeginRequest);
			prm.add_endRequest(EndRequest);

			try {
				for(n = 0; n < document.anchors.length; n++) {
					//if(window.location.href.indexOf(document.anchors[n].href) == -1) {
						if (document.anchors[n].href.indexOf('TreeView') == -1) {
							document.anchors[n].onclick = BeginRequest;
						}
					//}
				}				
			} catch (e) {
			}

			window.onload = function() {
				EndRequest();
			}
		} catch (e) {
		}
	}
