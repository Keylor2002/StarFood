function copyToClipboard(text) {
	navigator.clipboard.writeText(text).then(function() {
		alert('Código copiado: ' + text);
	}, function(err) {
		console.error('Error al copiar el texto: ', err);
	});
}
function toggleSuspend(id) {
    if (confirm("¿Estás seguro de que deseas habilitar/deshabilitar esta categoría?")) {
        $.ajax({
            url: '@Url.Action("ToggleSuspend", "Category")',
            type: 'POST',
            data: { id: id },
            success: function (response) {
                if (response.success) {
                    location.reload();
                } else {
                    alert('Error al habilitar/deshabilitar la categoría.');
                }
            },
            error: function () {
                alert('Error en la solicitud.');
            }
        });
    }
}

$(document).ready(function () {

    // Funcionalidad del dropdown de usuario
    $('#see-options').on('click', function (e) {
        e.preventDefault();
        $(this).toggleClass('active');
        $(this).next('.dropdown-menu').toggleClass('show');
    });

    // Cerrar dropdown al hacer clic fuera
    $(document).on('click', function (e) {
        if (!$(e.target).closest('#see-options, .dropdown-menu').length) {
            $('#see-options').removeClass('active');
            $('.dropdown-menu').removeClass('show');
        }
    });
});