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


$('#exampleModal9').on('show.bs.modal', function (event) {
	var button = $(event.relatedTarget)
	var nombre = button.data('nombre')
	var apellido = button.data('apellido')
	var email = button.data('email')
	var cedula = button.data('cedula')
	var fechareserva = button.data('fechareserva')
	var fechapago = button.data('fechadepago')
	var huespedes = button.data('huespedes')
	var tipohabitacion = button.data('tipohabitacion')
	var pagototal = button.data('pagototal')
	var telefono = button.data('telefono')



	var modal = $(this)
	modal.find('.modal-body .nombre').text(nombre)
	modal.find('.modal-body .telefono').text(telefono)
	modal.find('.modal-body .apellido').text(apellido)
	modal.find('.modal-body .email').text(email)
	modal.find('.modal-body .cedula').text(cedula)
	modal.find('.modal-body .fechareserva').text(fechareserva)
	modal.find('.modal-body .fechapago').text(fechapago)
	modal.find('.modal-body .huespedes').text(huespedes)
	modal.find('.modal-body .tipohabitacion').text(tipohabitacion)
	modal.find('.modal-body .pagototal').text(pagototal)



})