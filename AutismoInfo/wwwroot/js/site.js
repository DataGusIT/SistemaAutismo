// Initialize AOS
document.addEventListener('DOMContentLoaded', function () {
    // Initialize AOS
    AOS.init({
        duration: 800,
        easing: 'ease-in-out',
        once: true
    });

    // Navbar scroll effect
    let lastScrollTop = 0;
    const navbar = document.querySelector('.navbar');

    window.addEventListener('scroll', function () {
        const currentScrollTop = window.pageYOffset || document.documentElement.scrollTop;

        if (navbar) {
            if (currentScrollTop > lastScrollTop && currentScrollTop > 50) {
                // Scrolling down
                navbar.classList.add('navbar-hidden');
            } else if (currentScrollTop < lastScrollTop) {
                // Scrolling up
                navbar.classList.remove('navbar-hidden');
            }
        }

        lastScrollTop = currentScrollTop <= 0 ? 0 : currentScrollTop;

        // Show/hide back to top button
        const backToTop = document.querySelector('.back-to-top');
        if (backToTop) {
            if (currentScrollTop > 300) {
                backToTop.classList.add('active');
            } else {
                backToTop.classList.remove('active');
            }
        }
    });

    // Back to Top Button functionality
    const backToTop = document.querySelector('.back-to-top');
    if (backToTop) {
        backToTop.addEventListener('click', function (e) {
            e.preventDefault();
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });
    }

    // Mobile menu toggle
    const mobileMenuBtn = document.querySelector('.mobile-menu-btn');
    const navLinks = document.querySelector('.nav-links');

    if (mobileMenuBtn && navLinks) {
        mobileMenuBtn.addEventListener('click', function () {
            navLinks.style.display = navLinks.style.display === 'flex' ? 'none' : 'flex';
        });
    }

    // FAQ toggle
    const faqItems = document.querySelectorAll('.faq-item');

    faqItems.forEach(item => {
        const question = item.querySelector('.faq-question');

        if (question) {
            question.addEventListener('click', () => {
                // Toggle current item
                item.classList.toggle('active');

                // Opcional: Feche outros itens
                // faqItems.forEach(otherItem => {
                //     if (otherItem !== item) {
                //         otherItem.classList.remove('active');
                //     }
                // });
            });
        }
    });

    // Testimonial slider
    const track = document.querySelector('.testimonial-track');
    const dots = document.querySelectorAll('.testimonial-dots .dot');
    const cards = document.querySelectorAll('.testimonial-card');
    let currentSlide = 0;

    function updateSlider() {
        if (!track || !cards.length || !dots.length) return;

        const cardWidth = cards[0].offsetWidth;
        track.style.transform = `translateX(-${currentSlide * cardWidth}px)`;

        dots.forEach((dot, index) => {
            dot.classList.toggle('active', index === currentSlide);
        });
    }

    // Initialize slider on page load
    updateSlider();

    // Add click event to dots
    dots.forEach((dot, index) => {
        dot.addEventListener('click', () => {
            currentSlide = index;
            updateSlider();
        });
    });

    // Auto slide every 5 seconds
    const slideInterval = setInterval(() => {
        if (cards.length) {
            currentSlide = (currentSlide + 1) % cards.length;
            updateSlider();
        }
    }, 5000);

    // Handle window resize for testimonial slider
    window.addEventListener('resize', updateSlider);

    // Smooth scrolling for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();

            const targetId = this.getAttribute('href');
            if (targetId === "#") return; // Ignora links com apenas "#"

            const target = document.querySelector(targetId);

            if (target) {
                window.scrollTo({
                    top: target.offsetTop - 80,
                    behavior: 'smooth'
                });

                // Close mobile menu if open
                const navLinks = document.querySelector('.nav-links');
                if (window.innerWidth < 768 && navLinks) {
                    navLinks.style.display = 'none';
                }
            }
        });
    });
});