function cambiarProvincia(var opcionSeleccionada) {
    var select = document.getElementById("provincia");
    var valorSeleccionado = document.getElementById("valorSeleccionado");

    // Obtiene el valor seleccionado del elemento <select>
    opcionSeleccionada = select.options[select.selectedIndex].value;
        

    return opcionSeleccionada
}
