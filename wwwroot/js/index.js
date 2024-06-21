function copyToClipboard(text) {
	navigator.clipboard.writeText(text).then(function() {
		alert('Código copiado: ' + text);
	}, function(err) {
		console.error('Error al copiar el texto: ', err);
	});
}

$(document).ready(function () {
	$('.toggle-enable').click(function () {
		var button = $(this);
		var employeeId = button.data('id');
		var isEnabled = button.data('enabled');

		$.ajax({
			url: '@Url.Action("ToggleEnable", "Category")',
			type: 'POST',
			data: { id: employeeId },
			success: function(response) {
				if (response.success) {
					if (isEnabled) {
						button.html('<i class="fas fa-heart"></i> Habilitar');
					} else {
						button.html('<i class="fas fa-heart-broken"></i> Deshabilitar');
					}
					button.data('enabled', !isEnabled);
				}
			},
			error: function() {
				alert('Error al cambiar el estado de habilitación');
			}
		});
	});
});


