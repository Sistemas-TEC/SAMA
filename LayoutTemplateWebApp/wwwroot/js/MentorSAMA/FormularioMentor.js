function cambiarProvincia() {
    var select1 = document.getElementById("selectProvincia");
    var select2 = document.getElementById("selectCanton");

    select1.addEventListener("change", function () {
        document.getElementById("select1").addEventListener("change", function () {
            var selectedValue = this.value;
            // Realiza una llamada al servidor para obtener las opciones para el segundo select
            $.get("/FormularioMentor/GetOptionsForSelect2", { selectedValue: selectedValue }, function (data) {
                // Limpia y llena el segundo select con las nuevas opciones
                var select2 = document.getElementById("select2");
                select2.innerHTML = "";
                for (var i = 0; i < data.length; i++) {
                    var option = document.createElement("option");
                    option.value = data[i].Value;
                    option.text = data[i].Text;
                    select2.appendChild(option);
                }
            });
        });
    }); 
    
}
