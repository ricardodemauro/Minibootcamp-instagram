$(document).ready(function () {
    if (Dropzone) {
        Dropzone.options.UploadForm = {
            maxFilesize: 20, // MB
            acceptedFiles: "image/*"
        };
    }
});