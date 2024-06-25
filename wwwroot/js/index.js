//function copyToClipboard(text) {
//	navigator.clipboard.writeText(text).then(function() {
//		alert('Código copiado: ' + text);
//	}, function(err) {
//		console.error('Error al copiar el texto: ', err);
//	});
//}
$(document).ready(function () {

    loadDataTable();

    $('.Toggle-Suspend').on('click', function () {
        var idCategoria = $(this).data('id');
        ToggleSuspend(idCategoria);
        

    });
    
});


function ToggleSuspend(idCategoria) {
    $.ajax({
        url: '/Category/ToggleSuspend',
        type: 'POST',
        data: { id: idCategoria },
        success: function (result) {
            if (result.success) {
                // Aquí puedes manejar el éxito de la operación si es necesario
                console.log('ToggleSuspend exitoso');
            } else {
                // Manejo de errores si result.success es false
                console.error('Error al intentar cambiar el estado de la categoría.');
                alert(result.message || 'Error al cambiar el estado de la categoría.');
            }
        },
        error: function (error) {
            // Manejo de errores en la solicitud AJAX
            console.error('Error al cambiar el estado:', error);
            alert('Error al intentar cambiar el estado de la categoría.');
        }
    });
}

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Category/GetAll",
            "dataSrc": "data"

        },
        "columns": [
            { "data": "IDCategoria", "width": "15%" },
            { "data": "Nombre",
                
         
                "render": function (data) {
                    return `
                    <a href="/Category/Edit/${data.I}" 
                       class="btn btn-primary mx-2>
                        <i class="bi bi-pencil-square"></i> Edit
                    </a>
                    `
                },

                "width": "30%"
            }

        ]
    });
}

//$(document).ready(function () {

//    // Funcionalidad del dropdown de usuario
//    $('#see-options').on('click', function (e) {
//        e.preventDefault();
//        $(this).toggleClass('active');
//        $(this).next('.dropdown-menu').toggleClass('show');
//    });

//    // Cerrar dropdown al hacer clic fuera
//    $(document).on('click', function (e) {
//        if (!$(e.target).closest('#see-options, .dropdown-menu').length) {
//            $('#see-options').removeClass('active');
//            $('.dropdown-menu').removeClass('show');
//        }
//    });
//});