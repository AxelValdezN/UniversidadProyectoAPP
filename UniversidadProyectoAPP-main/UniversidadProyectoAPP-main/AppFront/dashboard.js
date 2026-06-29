document.addEventListener('DOMContentLoaded', () => {

    // Se obliga a mover al usuario al inicio de sesión si no hay usuario
    const isAuthenticated = localStorage.getItem('appdo_isAuthenticated');
    if (!isAuthenticated) {
        window.location.href = 'index.html';
        return; 
    }

    // Sacamos el nombre y ponemos un escudo por si viene la palabra 'undefined' literal
    let userName = localStorage.getItem('appdo_userName');
    if (!userName || userName === 'undefined' || userName === 'null') {
        userName = 'Usuario';
    }

    // Ponemos los datos en el HTML
    const userNameElement = document.getElementById('userName');
    const userAvatarElement = document.getElementById('userAvatar');

    if (userNameElement && userAvatarElement) {
        userNameElement.innerHTML = `Hola, ${userName} 👋`;
        userAvatarElement.textContent = userName.charAt(0).toUpperCase(); 
    }

    // En el futuro aquí inyectaremos los recordatorios pendientes
});