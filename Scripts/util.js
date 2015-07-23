//Funções para exibição de aguardando processamento no webgrid

function onUpdating() {
    // get the update progress div
    var updateProgressDiv = $get('updateProgressDiv');

    //  get the gridview element        
    var gridView = $get('<%= this.grid.ClientID %>');

    // make it visible
    updateProgressDiv.style.display = '';

    // get the bounds of both the gridview and the progress div
    var gridViewBounds = Sys.UI.DomElement.getBounds(gridView);
    var updateProgressDivBounds = Sys.UI.DomElement.getBounds(updateProgressDiv);

    var x;
    var y;

    //    do the math to figure out where to position the element
    if ($get('rdoCenter').checked) {
        //  center of gridview
        x = gridViewBounds.x + Math.round(gridViewBounds.width / 2) - Math.round(updateProgressDivBounds.width / 2);
        y = gridViewBounds.y + Math.round(gridViewBounds.height / 2) - Math.round(updateProgressDivBounds.height / 2);
    }
    else if ($get('rdoTopLeft').checked) {
        //  top left of gridview
        x = gridViewBounds.x;
        y = gridViewBounds.y;
    }
    else {
        //  top right of gridview
        x = (gridViewBounds.x + gridViewBounds.width - updateProgressDivBounds.width);
        y = gridViewBounds.y;
    }

    //    set the progress element to this position
    Sys.UI.DomElement.setLocation(updateProgressDiv, x, y);
}

function onUpdated() {
    // get the update progress div
    var updateProgressDiv = $get('updateProgressDiv');
    // make it invisible
    updateProgressDiv.style.display = 'none';
}

//fim Funções para exibição de aguardando processamento no webgrid

//função para imprimir só uma div
function PrintElementID(id, pg) {
        var oPrint, oJan;
        oPrint  = window.document.getElementById(id).innerHTML;
        oJan    = window.open(pg);
        oJan.document.write(oPrint);
        oJan.history.go();
        oJan.window.print();
}