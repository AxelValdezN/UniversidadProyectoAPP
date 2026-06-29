document.addEventListener('DOMContentLoaded', () => {
    const formNuevoEvento = document.getElementById('formNuevoEvento');

    if (formNuevoEvento) {
        formNuevoEvento.addEventListener('submit', (e) => {
            e.preventDefault();

            // Recolectamos los datos de los inputs
            const nuevoEvento = {
                id: Date.now().toString(), // Generamos un ID único con la fecha actual
                titulo: document.getElementById('titulo').value.trim(),
                fecha: document.getElementById('fecha').value,
                hora: document.getElementById('hora').value,
                categoria: document.getElementById('categoria').value,
                prioridad: document.getElementById('prioridad').value,
                notas: document.getElementById('notas').value.trim(),
                estado: 'pendiente', // se deja todos los eventos como pendientes 
                monto: parseFloat(document.getElementById('monto').value),
            };

            // Traemos el historial existente o creamos un arreglo vacío si es el primero
            let eventosGuardados = JSON.parse(localStorage.getItem('appdo_eventos')) || [];

            // Se agrega el nuevo evento a la lista
            eventosGuardados.push(nuevoEvento);

            // guardamos la lista actualizada en el LocalStorage
            localStorage.setItem('appdo_eventos', JSON.stringify(eventosGuardados));

            // Retroalimentación y redirección.
            alert("¡Evento guardado con éxito!");
            window.location.href = 'dashboard.html';
        });
    }
});