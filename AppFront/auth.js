document.addEventListener('DOMContentLoaded', () => {
    const loginForm = document.getElementById('loginForm');

    if (loginForm) {
        loginForm.addEventListener('submit', async (e) => {
            e.preventDefault(); 

            const correo = document.getElementById('correo').value.trim();
            const password = document.getElementById('password').value.trim();

            if (!correo || !password) {
                alert("Por favor, llena ambos campos para continuar.");
                return;
            }

            try {
                const response = await fetch('http://localhost:5236/api/auth/login', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ email: correo, password: password })
                });

                if (response.ok) {
                    const data = await response.json();
                    
                    //  obligamos a meter el nombre sea como sea 
                    const nombreReal = data.nombre || data.Nombre || "Usuario";
                    
                    // Guardamos la sesión
                    localStorage.setItem('appdo_isAuthenticated', 'true');
                    localStorage.setItem('appdo_token', data.token);
                    localStorage.setItem('appdo_userName', nombreReal);
                    localStorage.setItem('appdo_userEmail', data.email);

                    // Redireccion
                    window.location.href = 'dashboard.html';
                } else {
                    alert("Usuario o contraseña incorrectos.");
                }

            } catch (error) {
                console.error("Error de conexión:", error);
                alert("No pudimos conectar con el servidor. Verifica que dotnet run esté activo.");
            }
        });
    }
});