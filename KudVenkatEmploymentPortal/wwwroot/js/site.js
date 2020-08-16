$(document).ready(function () {
    $('.custom-file-input').on('change', (function () {
        var files = $(this)[0].files;
        if (files.length > 1) {
            $(this).next().html(files.length + " files selected");
        }
        else {
            $(this).next().html(files[0].name);
        }

        //var filename = $(this).val().split("\\").pop();
        //$(this).next().html(filename);
    }));
});