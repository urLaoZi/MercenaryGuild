// Управление музыкой
const bgMusic = document.getElementById('bgMusic');
const musicToggle = document.getElementById('musicToggle');
let isMusicPlaying = false;

musicToggle.addEventListener('click', () => {
    isMusicPlaying = !isMusicPlaying;
    if (isMusicPlaying) {
        bgMusic.play();
        musicToggle.innerHTML = '<i class="fas fa-volume-up"></i>';
    } else {
        bgMusic.pause();
        musicToggle.innerHTML = '<i class="fas fa-volume-mute"></i>';
    }
});

// Глитч-эффект для заголовка
const title = document.querySelector('.neon-text');
setInterval(() => {
    title.classList.toggle('glitch-effect');
}, 3000);

// Рендер наёмников с аватарками
function renderMercenaries(mercenaries) {
    const tableBody = document.querySelector('.cyber-table tbody');
    tableBody.innerHTML = '';

    mercenaries.forEach(merc => {
        const row = document.createElement('tr');
        row.innerHTML = `
            <td>${merc.id}</td>
            <td>
                <img src="images/avatars/${merc.name.toLowerCase().split(' ')[0]}.png" 
                     alt="${merc.name}" class="cyber-avatar">
                <span>${merc.name}</span>
            </td>
            <td><span class="cyber-rank rank-${merc.rank.toLowerCase()}">${merc.rank}</span></td>
            <td>${new Date(merc.registrationDate).toLocaleDateString()}</td>
            <td><span class="status-active">ONLINE</span></td>
        `;
        tableBody.appendChild(row);
    });
}
// Анимация неоновых элементов
document.querySelectorAll('.cyber-tab').forEach(tab => {
    tab.addEventListener('mouseenter', () => {
        tab.style.textShadow = `0 0 10px ${getRandomNeonColor()}`;
    });
    tab.addEventListener('mouseleave', () => {
        tab.style.textShadow = 'none';
    });
});

function getRandomNeonColor() {
    const colors = ['#ff2a6d', '#05d9e8', '#d300c5', '#ff9a00'];
    return colors[Math.floor(Math.random() * colors.length)];
}