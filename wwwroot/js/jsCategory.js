//var dataTable;




//$(document).ready(function (){
//    loadDataTable();
//});

//function loadDataTable() {
//    dataTable = $('#tblDataCate').DataTable({
//        "ajax": {
//            "url": "/Category/GetAll"
//        },
//        "columns": [
//            { "data": "name", "width": "15%" },
//            {
//                "data": "IDCategoria",
//                "render": function (data) {
//                    return `
//                            <div class="btn-group w-55">
//                            <a href="/Category/Edit?id=${data}"
//                            <i class="bi bi-pencil-circle">Editar</i>

//                    `;

//                },
//                "width": "15%"
//            }
//        ]
//    });
//}

@{
    ViewBag.Title = "Categorías";
    Layout = "~/Views/Shared/_Layout.cshtml";
}

<h2>Categorías</h2>

<!--Botón para crear una nueva categoría-- >
<button id="btnCreateCategory" class="btn btn-primary">Crear Categoría</button>

<!--Tabla para mostrar las categorías-- >
<table id="categoriesTable" class="table table-bordered">
    <thead>
        <tr>
            <th>ID Categoría</th>
            <th>Nombre Categoría</th>
            <th>Acciones</th>
        </tr>
    </thead>
    <tbody>
        <!-- Contenido generado dinámicamente -->
    </tbody>
</table>

<!--Modal para Crear / Editar Categoría-- >
    <div class="modal fade" id="categoryModal" tabindex="-1" aria-labelledby="categoryModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="categoryModalLabel">Crear Categoría</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form id="categoryForm">
                        <input type="hidden" id="categoryId" name="IDCategoria" />
                        <div class="mb-3">
                            <label for="categoryName" class="form-label">Nombre Categoría</label>
                            <input type="text" class="form-control" id="categoryName" name="NombreCategoria" required />
                        </div>
                        <button type="submit" class="btn btn-primary">Guardar</button>
                    </form>
                </div>
            </div>
        </div>
    </div>

@section Scripts {
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/category.js"></script>
}
