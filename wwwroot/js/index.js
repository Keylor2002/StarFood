
//Category Scripts
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

//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": {
//            "url": "/Category/GetAll",
//            "dataSrc": "data"

//        },
//        "columns": [
//            { "data": "IDCategoria", "width": "15%" },
//            {
//                "data": "Nombre",


//                "render": function (data) {
//                    return `
//                    <a href="/Category/Edit/${data.I}" 
//                       class="btn btn-primary mx-2>
//                        <i class="bi bi-pencil-square"></i> Edit
//                    </a>
//                    `
//                },

//                "width": "30%"
//            }

//        ]
//    });
//}
    function copyToClipboard(text) {
        navigator.clipboard.writeText(text).then(function () {
            alert('ID copiado al portapapeles: ' + text);
        }, function (err) {
            console.error('Could not copy text: ', err);
        });
        }
