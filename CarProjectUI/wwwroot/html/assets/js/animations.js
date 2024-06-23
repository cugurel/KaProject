(function() {

	"use strict";
  
	var app = {
		
		init: () => {

			//=== Animations ===\\
			app.animations.init();
			
		},

		DELAY: 0.1,
		animations: {

			init: () => {

				/*=== Settings ===*/
				app.animations.settings();

				/*=== Layouts ===*/
				app.animations.layouts();

				/*=== Components ===*/
				app.animations.components();

				/*=== Sections ===*/
				app.animations.sections();

				/*=== Animate items ===*/
				app.animations.animateItems();
				app.animations.animateWooItems();

			},

			/*=== Settings ===*/
			settings: () => {

				/*--- Plugin registration ---*/
				gsap.registerPlugin(ScrollTrigger);

				/*--- Default ScrollTrigger settings ---*/
				ScrollTrigger.defaults({ start: "top 90%" });

			},

			/*=== Components ===*/
			components: () => {

				/*--- Pagination ---*/
				app.animations.pagination();

				/*--- Bread crumbs ---*/
				app.animations.breadCrumbs();

			},

			/*=== Layouts ===*/
			layouts: () => {

				/*--- Header ---*/
				app.animations.header();

			},

			/*=== Sections ===*/
			sections: () => {

				/*--- Section Heading ---*/
				app.animations.sectionHeading();

				/*--- Section footer ---*/
				app.animations.sectionFooter();

                /*--- Intro ---*/
				app.animations.intro();

                /*--- About ---*/
				app.animations.about();

                /*--- Banner Row ---*/
                app.animations.bannerRow();

			},

			/*--- Pagination ---*/
			pagination: () => {

				const pagination = document.querySelectorAll(".pagination");
				if(pagination.length) {

					let tl = gsap.timeline({
						scrollTrigger: {
							trigger: pagination
						}
					});

					tl.from(pagination, { y: 30, opacity: 0, delay: app.DELAY }); 

				}

			},
			/*--- Bread crumbs ---*/
			breadCrumbs: () => {

				if(document.querySelectorAll(".bread-crumbs").length) {

					gsap.from(".bread-crumbs-list", { opacity: 0, delay: 0.25 });

				}

			},

			/*--- Header ---*/
			header: () => {

				if(document.querySelectorAll(".header-top").length) {
					gsap.fromTo(".header-top-info, .header-top-links", { opacity: 0 }, { opacity: 1, duration: 0.4, delay: 0.2, stagger: 0.1 });
				}
				gsap.fromTo(".logo img, .main-mnu, .header-actions", { opacity: 0 }, { opacity: 1, duration: 0.4, delay: 0.2, stagger: 0.1 });

			},

			/*--- Section Heading ---*/
			sectionHeading: () => {

				const sectionHeadings = gsap.utils.toArray(".section-heading-animate");

				if(sectionHeadings.length) {

					sectionHeadings.forEach(heading => {
						
						let tl = gsap.timeline({
								scrollTrigger: {
									trigger: heading
								}
							});

						tl.from(heading, { opacity: 0, delay: app.DELAY }); 

					});
	
				}

			},
			/*--- Section footer ---*/
			sectionFooter: () => {

				const sectionFooters = gsap.utils.toArray(".section-footer-animate");

				if(sectionFooters.length) {

					sectionFooters.forEach(footer => {
						
						let tl = gsap.timeline({
								scrollTrigger: {
									trigger: footer
								}
							});

						tl.from(footer, { opacity: 0, y: 20, delay: app.DELAY }); 

					});
	
				}

			},

            /*--- Intro ---*/
            intro: () => {

                const intro = gsap.utils.toArray(".intro");
    
                if(intro.length) {
    
                    intro.forEach(item => {
                            
                        let tl = gsap.timeline({
                                scrollTrigger: {
                                    trigger: item
                                }
                            });
    
                        tl.from(item.querySelectorAll(".section-subheading, h1, h2, h3, .section-desc, .btn-group"), { opacity: 0, y: 15, stagger: 0.1, delay: app.DELAY }); 
    
                    });
        
                }
    
            },
            /*--- About ---*/
            about: function() {

                const about = gsap.utils.toArray(".animate-about");
    
                if(about.length) {
    
                    about.forEach(item => {
                            
                        let tl = gsap.timeline({
                                scrollTrigger: {
                                    trigger: item
                                }
                            });
    
                        tl.from(item.querySelectorAll(".about-item"), { opacity: 0, x: 20, stagger: 0.1, delay: app.DELAY }, "start");
                        
                        if(item.querySelector(".about-imgs-1") !== null) {
                            tl.from(item.querySelectorAll(".about-media-item")[0], { opacity: 0, scale: 0.8, transformOrigin:"center", delay: app.DELAY+0.1 }, "start");
                        }
                        if(item.querySelector(".about-imgs-2") !== null) {
                            tl.from(item.querySelectorAll(".about-media-item")[0], { opacity: 0, y: -30, delay: app.DELAY+0.1 }, "start");
                            tl.from(item.querySelectorAll(".about-media-item")[1], { opacity: 0, y: 30, delay: app.DELAY+0.2 }, "start");
                        }
                        if(item.querySelector(".about-imgs-3") !== null) {
                            tl.from(item.querySelectorAll(".about-media-item")[0], { opacity: 0, x: -30, delay: app.DELAY+0.1 }, "start");
                            tl.from(item.querySelectorAll(".about-media-item")[1], { opacity: 0, y: -30, delay: app.DELAY+0.2 }, "start");
                            tl.from(item.querySelectorAll(".about-media-item")[2], { opacity: 0, y: 30, delay: app.DELAY+0.3 }, "start");
                        }
    
                        if(item.querySelectorAll(".about-circular-item").length) {
                            tl.from(item.querySelectorAll(".about-circular-media"), { opacity: 0, stagger: 0.1, delay: app.DELAY }, "start");
                            tl.from(item.querySelector(".about-circular-content .about-circular-heading"), { opacity: 0, scale: 0.7, delay: app.DELAY }, "start");
                            tl.from(item.querySelector(".about-circular-content .about-circular-desc"), { opacity: 0, scale: 0.7, delay: app.DELAY }, "start");
                        }
    
                    });
        
                }
    
            },
            /*--- Banner Row ---*/
            bannerRow: function() {

                const banner = gsap.utils.toArray(".banner");
    
                if(banner.length) {
    
                    banner.forEach(item => {
                            
                        let tl = gsap.timeline({
                                scrollTrigger: {
                                    trigger: item
                                }
                            });
    
                        tl.from(item.querySelectorAll(".section-subheading, h1, h2, h3, .section-desc, .btn-group"), { opacity: 0, y: 15, stagger: 0.1, delay: app.DELAY }); 
    
                    });
        
                }
    
            },

			/*=== Animate items ===*/
			animateItems: () => {

				app.animations.itemsAnim(".section-animate-items", ".animate-item");

			},

			animateWooItems: () => {

				app.animations.itemsAnim(".products", ".product");

			},

			/*--- Items animation ---*/
			itemsAnim: (sectionClass, itemClass) => {

				const sections = gsap.utils.toArray(sectionClass);

				if(sections.length) {

					sections.forEach(section => {

						const item = section.querySelectorAll(itemClass);
						const columns = section.getAttribute('data-body-columns');
						let staggerGrid = "auto";

						if(columns !== null) { staggerGrid = [1, parseInt(columns)]; }
						if(item.length) { app.animations.itemsBatch(item, staggerGrid); }

					});

				}

			},
			/*--- Items batch ---*/
			itemsBatch: (item, staggerGrid) => {

				gsap.set(item, {y: 30, opacity: 0, ease: "power3.out"});
				ScrollTrigger.batch(item, {
					interval: 0.1,
					onEnter: function(batch) {
						gsap.to(batch, {
							opacity: 1,
							y: 0,
							delay: app.DELAY,
							stagger: {
								each: 0.1,
								grid: staggerGrid
							},
							overwrite: true
						});
					},
					onEnterBack: function(batch) {
						gsap.set(batch, { opacity: 1, y: 0 });
					}
				});

			},
			
		},
		
	}

	app.init();
 
}());
