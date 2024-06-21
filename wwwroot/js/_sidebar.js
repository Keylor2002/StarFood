$(document).ready(function() {
    // Inicialización de los menús desplegables
    $('.nav-link[data-bs-toggle="collapse"]').on('click', function() {
        $(this).next('.collapse').collapse('toggle');
    });

    // Funcionalidad del dropdown de usuario
    $('#dropdownUser1').on('click', function(e) {
        e.preventDefault();
        $(this).toggleClass('active');
        $(this).next('.dropdown-menu').toggleClass('show');
    });

    // Cerrar dropdown al hacer clic fuera
    $(document).on('click', function(e) {
        if (!$(e.target).closest('#dropdownUser1, .dropdown-menu').length) {
            $('#dropdownUser1').removeClass('active');
            $('.dropdown-menu').removeClass('show');
        }
    });
});
