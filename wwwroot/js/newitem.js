$(document).ready(function () {
    $('#categoriesTable').DataTable({
        responsive: true,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.10.25/i18n/Spanish.json'
        }
    });

    $('#btnCreateCategory').click(function () {
        openNewItem();
    });

    $('.newitem-close').click(function () {
        closeNewItem();
    });

    $(window).click(function (event) {
        if ($(event.target).hasClass('newitem')) {
            closeNewItem();
        }
    });
});

function openNewItem() {
    document.getElementById("newItemSidebar").style.width = "400px";
}

function closeNewItem() {
    document.getElementById("newItemSidebar").style.width = "0";
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
