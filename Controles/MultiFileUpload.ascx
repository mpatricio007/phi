<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MultiFileUpload.ascx.cs" Inherits="Medusa.Controles.MultiFileUpload" %>
<script type="text/javascript">
    function addFileUploadBox() {
        if (!document.getElementById || !document.createElement)
            return false;

        var uploadArea = document.getElementById("upload-area");

        if (!uploadArea)
            return;

        var newLine = document.createElement("br");
        uploadArea.appendChild(newline);

        var newUploadBox = document.createElement("input");
        
        // Set up the new input for file uploads
        newUploadBox.type = "file";
        newUploadBox.size = "60";


        // The new box needs a name and an ID
        if (!addFileUploadBox.lastAssignedId)
            addFileUploadBox.lastAssignedId = 100;

        newUploadBox.setAttribute("id", "dynamic" + addFileUploadBox.lastAssignedId);
        newUploadBox.setAttribute("name", "dynamic:" + addFileUploadBox.lastAssignedId);
        uploadArea.appendChild(newUploadBox);
        addFileUploadBox.lastAssignedId++;
    }
</script>

<p id="upload-area">
   <input id="file" type="file" runat="server" size="60" /><input id="AddFile" type="button" value="adicionar" 
        onclick="addFileUploadBox()" />
</p>


