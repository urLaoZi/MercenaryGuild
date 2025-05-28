document.addEventListener('DOMContentLoaded', () => {
    // Инициализация
    initMusicPlayer();
    initMatrixEffect();
    loadMercenaries();
    setupTabs();

    // Загрузка наёмников
    async function loadMercenaries() {
        try {
            const response = await fetch('/api/mercenaries');
            const data = await response.json();
            renderMercenaries(data);
        } catch (error) {
            console.error('Ошибка загрузки:', error);
        }
    }

    // Рендер карточек
    function renderMercenaries(mercenaries) {
        const container = document.getElementById('mercenaries-container');
        container.innerHTML = '';

        mercenaries.forEach(merc => {
            const card = document.createElement('div');
            card.className = 'merc-card';
            card.innerHTML = `
                <div class="merc-header">
                    <img src="/images/avatars/${merc.name.toLowerCase().replace(/[^a-z0-9]/g, '')}.png" 
                         class="cyber-avatar" alt="${merc.name}">
                    <h3>${merc.name}</h3>
                    <span class="cyber-rank rank-${merc.rank.toLowerCase()}">${merc.rank}</span>
                </div>
                <div class="merc-body">
                    <p class="cyber-bio">${merc.bio || 'Нет данных'}</p>
                    <div class="merc-stats">
                        <span><i class="fas fa-calendar-alt"></i> ${new Date(merc.registrationDate).toLocaleDateString()}</span>
                    </div>
                </div>
            `;
            container.appendChild(card);
        });
    }
});