
        // Search functionality
    const searchInput = document.getElementById('searchInput');
    const contactsList = document.getElementById('contactsList');
    const contactItems = document.querySelectorAll('.contact-item');

    searchInput.addEventListener('input', function() {
            const searchTerm = this.value.toLowerCase();

            contactItems.forEach(item => {
                const name = item.dataset.name.toLowerCase();
    const title = item.querySelector('.contact-title').textContent.toLowerCase();

    if (name.includes(searchTerm) || title.includes(searchTerm)) {
        item.style.display = 'flex';
                } else {
        item.style.display = 'none';
                }
            });
        });

    // Connect button functionality
    function connectUser(button) {
            if (button.classList.contains('connected')) {
        button.textContent = 'Connect';
    button.classList.remove('connected');
            } else {
        button.textContent = 'Connected';
    button.classList.add('connected');

    // Add a subtle animation
    button.style.transform = 'scale(0.95)';
                setTimeout(() => {
        button.style.transform = 'scale(1)';
                }, 150);
            }
        }

        // Add click animation to contact items
        contactItems.forEach(item => {
        item.addEventListener('click', function (e) {
            // Don't trigger if clicking the connect button
            if (e.target.classList.contains('connect-btn')) return;

            // Add a subtle click effect
            this.style.transform = 'scale(0.98)';
            setTimeout(() => {
                this.style.transform = 'scale(1)';
            }, 100);
        });
        });

    // Profile avatar click
    document.querySelector('.profile-avatar').addEventListener('click', function() {
        alert('Profile menu would open here');
        });

    // Menu button click
    document.querySelector('.menu-btn').addEventListener('click', function() {
        alert('Navigation menu would open here');
        });
