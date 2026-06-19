document.addEventListener('DOMContentLoaded', () => {
    const registroForm = document.getElementById('registroForm');

    if (registroForm) {
        registroForm.addEventListener('submit', async (e) => {
            e.preventDefault(); 

            const nombre = document.getElementById('nombre').value.trim();
            const correo = document.getElementById('correo').value.trim();
            const password = document.getElementById('password').value.trim();
            const confirmPassword = document.getElementById('confirmPassword').value.trim();
            // validamos si las contraseñas son iguales
            if (password !== confirmPassword) {
                alert("Las contraseñas no coinciden. Por favor, verifícalas.");
                return;
            }
            try {
                const response = await fetch('http://localhost:5236/api/auth/register', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    // Mandamos el nombre tambien
                    body: JSON.stringify({ nombre: nombre, email: correo, password: password })
                });

                if (response.ok) {
                    alert("¡Cuenta creada con éxito! Ahora puedes iniciar sesión.");
                    window.location.href = 'index.html';
                } else {
                    // Si el servidor nos manda un error (como: el correo ya existe)
                    const errorData = await response.json();
                    alert(errorData.message || "Hubo un error al registrar el usuario.");
                }

            } catch (error) {
                console.error("Error de conexión:", error);
                alert("No pudimos conectar con el servidor.");
            }
        });
    }
});