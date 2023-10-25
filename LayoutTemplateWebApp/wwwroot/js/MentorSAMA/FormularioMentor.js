var select1 = document.getElementById("selectProvincia");
var select2 = document.getElementById("selectCanton");

select.addEventListener("change", function () {
    var selectedVal = select1.value;
    
    return selectedVal;
});

function cambiarProvincia() {
    var select = document.getElementById("selectProvincia");

    // Obtiene el valor seleccionado del elemento <select>
    opcionSeleccionada = select.options[select.selectedIndex].value;
    return opcionSeleccionada;    
    
}
