// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#exampleModal2').on('show.bs.modal', function (event) {
	var button = $(event.relatedTarget)
	var id = button.data('id')
	var modal = $(this)
	modal.find('.modal-body .hola').val(id)

})


$('#exampleModal3').on('show.bs.modal', function (event) {
	var button = $(event.relatedTarget)
	var id = button.data('id')
	var nombre = button.data('nombre')
	var cama = button.data('camas')
	var precio = button.data('precio')
	var huespedes = button.data('huespedes')

	var modal = $(this)
	modal.find('.modal-body .id').val(id)
	modal.find('.modal-body .nombre').val(nombre)
	modal.find('.modal-body .cama').val(cama)
	modal.find('.modal-body .precio').val(precio)
	modal.find('.modal-body .huespedes').val(huespedes)


})