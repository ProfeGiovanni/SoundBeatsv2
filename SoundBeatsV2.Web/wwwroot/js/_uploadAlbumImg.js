
// ====================================================================
$(document).ready(function () {

    var upload = new FileUploadWithPreview('profileImage', {
        showDeleteButtonOnImages: true,
        text: {
            chooseFile: 'Selecciona un archivo',
            browse: 'Cargar ...',
            selectedCount: 'Custom Files Selected Copy',
        },
        maxFileCount: 1,
        //images: {
        //    baseImage: "../assets/images/corporativo/LogoSquare.png",
        //},
        //presetFiles: [
        //    '../public/logo-promosis.png',
        //    'https://images.unsplash.com/photo-1557090495-fc9312e77b28?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=668&q=80',
        //],
    })

    // Cambio de imagen de fondo en selección de Imagen de contexto
    var base64 = $('#photoString').attr('data-success');
    $("#courseImage").css("background-image", "url('" + base64 + "')");


    flatpickr.localize(flatpickr.l10ns.es);
    flatpickr("#Birthday", {
        //    locale: "es",
        altInput: true,
        altFormat: "F j, Y",
        dateFormat: "Y-m-d",
    });

});
