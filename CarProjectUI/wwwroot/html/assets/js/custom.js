(function() {

	"use strict";
  
	var app = {
		
		init: function() {

			//=== Main visible ===\\
			this.mainVisible();

			//=== lazy loading effect ===\\
			this.lazyLoading();

			//=== Cookie ===\\
			this.cookieCheck();

			this.setUpListeners();

			//=== Custom scripts ===\\
			this.headerFixed.init();
			this.btnHover();
			this.appendMfBg();
			this.appendBtnTop();
			this.formingHrefTel();
			this.contentTable();
			this.clockCountDown();
			this.responsiveMenu();
			this.playVideo();
			this.counters.init();
			this.progressbars.init();
			this.imageComparison();

			//=== Plugins ===\\
			this.device();
			this.popUp();
			this.lightGallery();
			this.carusels();
			this.isotopeProjects();
			this.isotopeGallery();
			this.isotopeGalleryMasonry();
			this.isotopeCareers();

		},
        
		setUpListeners: function() {

			//=== Cookie ===\\
			$(".mc-btn").on("click", this.cookieSet);

			//=== Ripple effect for buttons ===\\
			$(".ripple").on("click", this.btnRipple);

			//=== Header search ===\\
			// Header search open
			$(".header-search-ico-search").on("click", this.headerSearchOpen);
			// Header search close \\
			$(".header-search-ico-close").on("click", this.headerSearchClose);
			// Header search close not on this element \\
			$(document).on("click", this.headerSearchCloseNotEl);

			//=== Header lang ===\\
			// Header lang open
			$(".header-lang-current").on("click", this.headerLangOpen);
			// Header lang close not on this element \\
			$(document).on("click", this.headerLangCloseNotEl);

			//=== Header mobile/tablet navbar ===\\
			// Header navbar toggle \\
			$(".header-navbar-btn").on("click", this.headerNavbarToggle);
			// Header navbar close not on this element \\
			$(document).on("click", this.headerNavbarNotEl);

			//=== Mobile/tablet main menu ===\\
			// Main menu toogle \\
			$(".main-mnu-btn").on("click", this.MainMenuToggle);
			// Main menu submenu toogle \\
			$(".mmm-btn").on("click", this.MainMenuSubmenuToggle);
			// Main menu close not on this element \\
			$(document).on("click", this.MainMenuCloseNotEl);

			//=== Side toggle ===\\
			$(".side-open").on("click", this.sideOpen);
			$(document).on("click", ".side-close, .side-visible", this.sideClose);

			//=== Tab ===\\
			$(".tabs-nav li").on("click", this.tab);

			//=== Accordion ===\\
			$(".accordion-trigger").on("click", this.accordion);

			//=== Sidebar category item ===\\
			$(".sidebar-cat-item-has-child > a").on("click", this.sidebarCatItemToggle);

			//=== UI elements ===\\
			$(".ui-nav li").on("click", this.ui);

			//=== Button top ===\\
			$(document).on("click", '.btn-top', this.btnTop);
			$(window).on("scroll", this.btnTopScroll);

			//=== Pricing: price switcher ===\\
			$(".pricing-toggle input").on("change", this.priceSwitcher);

			$(document).on("click", '.scroll-to', this.scrollTo);

			$(window).resize(app.debounce(app.responsiveMenu));

			$(".about-circular-media").hover( function() { $(this).closest(".about-circular-item").addClass("active").siblings().removeClass("active"); }, function() {} );
			
		},

		//=== Body visible ===\\
		mainVisible: function() {

			$(".main").addClass("main-visible");

		},

		//=== Cookie ===\\
		COOKIENAME: 'pathsoft-cookie',
		COOKIEDURATION: 1000,
		COOKIEEXDAYS: 30,
		cookieCheck: function() {

			var cookieMessage = $(".cookie-message");

			if(!this.getCookie(this.COOKIENAME)) {
				setTimeout(function() {
					cookieMessage.addClass("open");
				}, this.COOKIEDURATION);
			}

		},
		cookieSet: function() {

			app.setCookie(app.COOKIENAME, 'enabled', app.COOKIEEXDAYS);
			$(this).closest(".cookie-message").removeClass('open');

		},
		setCookie: function(cname, cvalue, exdays) {
			var d = new Date();
			d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
			var expires = "expires=" + d.toUTCString();
			document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
		},
		getCookie: function(name) {
			var matches = document.cookie.match(new RegExp(
				"(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
			));
			return matches ? decodeURIComponent(matches[1]) : undefined;
		},

		appendMfBg: function() {

			$("body").append('<div class="mf-bg"></div>');

		},

		appendBtnTop: function() {

			$("body").append('<div class="btn-top"><svg class="btn-icon-right" viewBox="0 0 13 9" width="13" height="9"><use xlink:href="assets/img/sprite.svg#arrow-right"></use></svg></div>');

		},

		btnTop: function() {
			
			$('html, body').animate({scrollTop: 0}, 1000, function() {
				$(this).removeClass("active");
			});

		},

		btnTopScroll: function() {
			
			var btnTop = $('.btn-top');
			
			if ($(this).scrollTop() > 700) {

				btnTop.addClass("active");

			} else {

				btnTop.removeClass("active");
				
			}

		},

		scrollTo: function() {

			$('html, body').animate({scrollTop: $($(this).attr('data-scroll-to')).position().top}, 1000);

		},

		//=== Header fixed ===\\
		headerFixed: {

			init: function() {

				if( $('.header-fixed').length ) {
	
					$(window).on("load resize scroll", app.headerFixed.handler);
	
				}
				
			},
	
			IS_FIXED: false,
	
			handler: function() {
	
				var header = $('.header-fixed');
				var height = header.outerHeight();
				var offsetTop = header.offset().top;
				var scrollTop = $(this).scrollTop();
	
				var wpadminbar = $('#wpadminbar');
				var wpadminbarHeight = wpadminbar.outerHeight();
	
				var headerStatic = $(".header-fixed-static");
				if(headerStatic.length) { 
					offsetTop = headerStatic.offset().top;
					headerStatic.css("height", height);
					if(wpadminbar.length) { offsetTop = offsetTop - wpadminbarHeight; }
				}
	
				if(scrollTop >= offsetTop) {
					if(!app.headerFixed.IS_FIXED) {
						header.addClass("fixed");
						header.after('<div class="header-fixed-static" style="height:' + height + 'px"></div>');
						if(wpadminbar.length) { header.css('top', wpadminbarHeight); }
					}
					app.headerFixed.IS_FIXED = true;
				} else {
					if(app.headerFixed.IS_FIXED) {
						header.removeClass("fixed");
						headerStatic.remove();
						if(wpadminbar.length) { header.css('top', '0'); }
					}
					app.headerFixed.IS_FIXED = false;
				}
	
			}

		},

		ui: function() {

			var _this = $(this),
				index = _this.index(),
				nav = _this.parent(),
				tabs = _this.closest(".ui"),
				items = tabs.find(".ui-item");

			if (!_this.hasClass("active")) {

				items
					.eq(index)
					.add(_this)
					.addClass("active")
					.siblings()
					.removeClass("active");

				/*nav
					.trigger("detach.ScrollToFixed")
					.scrollToFixed({
						marginTop: $(".header-fixed").outerHeight() + 20,
						zIndex: 2,
						limit: $(".footer").offset().top - nav.outerHeight() - 40,
						preAbsolute: function() { $(this).css({"opacity": 0, "visability": "hidden"}); },
						postUnfixed: function() { $(this).css({"opacity": 1, "visability": "visible"}); },
						postAbsolute: function() { $(this).css({"opacity": 1, "visability": "visible"}); },
					});
				*/

				if ($(document).scrollTop() > 0) {
					$("html, body").animate({ scrollTop: 0 }, 500);
				}
			
			}

		},

		//=== Tab ===\\
		tab: function() {

			var _this = $(this),
				index = _this.index(),
				tabs = _this.closest(".tabs"),
				items = tabs.find(".tabs-item");

			if (!_this.hasClass("active")) {

				items
					.eq(index)
					.add(_this)
					.addClass("active")
					.siblings()
					.removeClass("active");
			
			}

		},

		//=== Accordion ===\\
		accordion: function(e) {

			e.originalEvent.preventDefault();

			var _this = $(this),
				item = _this.closest(".accordion-item"),
				container = _this.closest(".accordion"),
				items = container.find(".accordion-item"),
				content = item.find(".accordion-content"),
				otherContents = container.find(".accordion-content"),
				duration = 300;

			if (!item.hasClass("active")) {
				items.removeClass("active");
				item.addClass("active");
				otherContents.stop(true, true).slideUp(duration);
				content.stop(true, true).slideDown(duration);
			} else {
				content.stop(true, true).slideUp(duration);
				item.removeClass("active");
			}

		},

		//=== Header search ===\\
		headerSearchOpen: function() {

			var _this = $(this),
				search = _this.closest(".header-search"),
				position = search.position(),
				form = search.find(".header-search-form");

			search.addClass("open");
			form.css('width', position.left + 6);

		},
		headerSearchClose: function() {

			$(this).closest(".header-search").removeClass("open");

		},
		headerSearchCloseNotEl: function(e) {

			if($(".header-search").hasClass("open")) {
				if ($(e.originalEvent.target).closest(".header-search").length) return;
				$(".header-search").removeClass("open");
				e.originalEvent.stopPropagation();
			}

		},
		
		//=== Header lang ===\\
		headerLangOpen: function() {

			$(this).parent().toggleClass("open");

		},
		headerLangCloseNotEl: function(e) {
			
			if($(".header-lang").hasClass("open")) {
				if ($(e.originalEvent.target).closest(".header-lang").length) return;
				$(".header-lang").removeClass("open");
				e.originalEvent.stopPropagation();
			}

		},

		//=== Mobile/tablet main menu ===\\
		MainMenuToggle: function() {

			var _this = $(this),
				_body = $("body"),
				headerH = _this.closest(".header").outerHeight(),
				mnu = $(".mmm"),
				offsetTop = $(".header-fixed").offset().top;
				
			mnu.css("padding-top", headerH);
			$(this).toggleClass("active");

			_body.toggleClass("mmm-open").scrollTop(offsetTop);
				
			if(_body.hasClass("mmm-open")) {
				$(".mf-bg").addClass("visible mm");
			} else {
				$(".mf-bg").removeClass("visible mm");
			}

		},
		MainMenuSubmenuToggle: function() {

			var _this = $(this),
				item = _this.parent(),
				content = item.find(".mmsm");

			item.toggleClass("open");
			content.slideToggle();

		},
		MainMenuCloseNotEl: function(e) {

			if($("body").hasClass("mmm-open")) {
				if ($(e.originalEvent.target).closest(".mmm, .main-mnu-btn").length) return;
				$("body").removeClass("mmm-open");
				$(".main-mnu-btn").removeClass("active");
				$(".mf-bg").removeClass("visible mm");
				e.originalEvent.stopPropagation();
			}

		},
		responsiveMenu: function() {

            if($(window).width() >= 1200) {

                var container = $(".main-mnu"),
                    list = container.find(".main-mnu-list");

                app.responsiveMenuRestore(list);
                
                container.addClass('main-mnu-js-init');
                var listWidth = list.width();
                list.addClass('hide');
                var containerWidth = container.width();

                if (listWidth > containerWidth) {
                    
                    var moreButton = list.find('.menu-item-more');
                    if(!moreButton.length) {
                        var moreButton = $('<li class="menu-item menu-item-has-children menu-item-more"><div><i class="material-icons md-24">more_horiz</i></div><ul class="sub-menu"></ul></li>');
                    }
                    
                    while (listWidth > containerWidth) {

                        var itemLastChild = list.find(">li").last();
                        moreButton.find('>ul').prepend(itemLastChild.clone());
                        itemLastChild.remove();

                        list.removeClass('hide');
                        listWidth = list.width();
                        list.addClass('hide');

                    }
                    
                    list.append(moreButton);

                }

                list.removeClass('hide');
                
            }

        },
        responsiveMenuRestore: function(list) {

            var menuItemMore = $('.menu-item-more');

            if( menuItemMore.length ) {

                $.each(menuItemMore.find('>ul>li'), function() {

                    list.append($(this).clone());

                });

                menuItemMore.remove();

            }

        },

		//=== Header mobile/tablet navbar ===\\
		headerNavbarToggle: function() {

			$(this).parent().toggleClass("open");

		},
		headerNavbarNotEl: function(e) {

			if ($(e.originalEvent.target).closest(".header-navbar").length) return;
			$(".header-navbar").removeClass("open");
			e.originalEvent.stopPropagation();

		},

		//=== Side toggle ===\\
		sideOpen: function(e) {

			e.originalEvent.preventDefault();

			var side = $($(this).attr("data-side"));

			if(side.length) {

				side.toggleClass("open");
				if(!e.currentTarget.classList.contains("psnav-item")) {
					$(".mf-bg").toggleClass("visible side-visible");
				}

			}

		},
		sideClose: function() {

			$(".side, .sidebar-filters").removeClass("open");
			$(".mf-bg").removeClass("visible side-visible");

		},

		//=== Ripple effect for buttons ===\\
		btnRipple: function(e) {
			
			var _this = $(this),
				offset = $(this).offset(),
				positionX = e.originalEvent.pageX - offset.left,
				positionY = e.originalEvent.pageY - offset.top;
			_this.append("<div class='ripple-effect'>");
			_this
				.find(".ripple-effect")
				.css({
					left: positionX,
					top: positionY
				})
				.animate({
					opacity: 0
				}, 1500, function() {
					$(this).remove();
				});

		},

		btnHover: function() {

			var btns = document.querySelectorAll(".btn, .el-ripple"),
				btn = [];

			btns.forEach(function(element, index) {

				var span = document.createElement("span"); 
				span.className = "el-ripple-circle";
				element.appendChild(span);

				// If The span element for this element does not exist in the array, add it.
				if (!btn[index])
				btn[index] = element.querySelector(".el-ripple-circle");

				element.addEventListener("mouseenter", function(e) {	
					btnHandler(element, index, e);			
				});

				element.addEventListener("mouseleave", function(e) {
					btnHandler(element, index, e);
				});
				
			});

			const btnHandler = function(element, index, e) {

				let offset = element.getBoundingClientRect(),
					left = e.pageX - offset.left - window.scrollX,
					top = e.pageY - offset.top - window.scrollY;

				btn[index].style.left = left + "px";
				btn[index].style.top = top + "px";

			}

		},

		//=== Forming href for phone ===\\
		formingHrefTel: function() {

			var linkAll = $('.formingHrefTel'),
				joinNumbToStringTel = 'tel:';

			$.each(linkAll, function () {
				var _this = $(this),
					linkValue = _this.text(),
					arrayString = linkValue.split("");

				for (var i = 0; i < arrayString.length; i++) {
					var thisNunb = app.isNumber(arrayString[i]);
					if (thisNunb === true || (arrayString[i] === "+" && i === 0)) {
						joinNumbToStringTel += arrayString[i];
					}
				}

				_this.attr("href", function () {
					return joinNumbToStringTel;
				});
				joinNumbToStringTel = 'tel:'

			});

		},

		isNumber: function(n) {

			return !isNaN(parseFloat(n)) && isFinite(n);

		},

		//=== Pricing: price switcher ===\\
		priceSwitcher: function() {

            var _this = $(this),
                container = _this.closest(".section"),
                firstPrice = container.find(".pricing-item-price-first"),
                secondPrice = container.find(".pricing-item-price-second");

            if(_this.prop("checked")) {

                firstPrice.addClass("none");
                secondPrice.removeClass("none");

            } else {

                firstPrice.removeClass("none");
                secondPrice.addClass("none");

            }

        },

		//=== Sidebar category item ===\\
		sidebarCatItemToggle: function(e) {

			e.originalEvent.preventDefault();

			var item = $(this).parent(),
				ul = item.find("> ul");

			item.toggleClass("open");
			ul.slideToggle();

		},
		
		//=== Content table responsive ===\\
		contentTable: function() {

			var contentTable = $(".content");
			if(contentTable.length) {
				
				$.each(contentTable.find("table"), function() {
					$(this).wrap("<div class='table-responsive-outer'></div>").wrap("<div class='table-responsive'></div>");
				});
				
			}

		},

		//=== Clock count down ===\\
		clockCountDown: function() {

			if($("#countdown").length) {
				this.clock("countdown", $("#countdown").attr("data-dedline"));
			}

		},
		getTimeRemaining: function(endtime) {

			var t = Date.parse(endtime) - Date.parse(new Date()),
				seconds = Math.floor((t / 1000) % 60),
				minutes = Math.floor((t / 1000 / 60) % 60),
				hours = Math.floor((t / (1000 * 60 * 60)) % 24),
				days = Math.floor(t / (1000 * 60 * 60 * 24));

			return {
				total: t,
				days: days,
				hours: hours,
				minutes: minutes,
				seconds: seconds
			};

		},
		clock: function(id, endtime) {

			var clock = document.getElementById(id),
				daysSpan = clock.querySelector(".days"),
				hoursSpan = clock.querySelector(".hours"),
				minutesSpan = clock.querySelector(".minutes"),
				secondsSpan = clock.querySelector(".seconds");

			function updateClock() {
				var t = app.getTimeRemaining(endtime);

				if (t.total <= 0) {
					document.getElementById("countdown").classList.add("hidden");
					document.getElementById("deadline-message").classList.add("visible");
					clearInterval(timeinterval);
					return true;
				}

				daysSpan.innerHTML = t.days;
				hoursSpan.innerHTML = ("0" + t.hours).slice(-2);
				minutesSpan.innerHTML = ("0" + t.minutes).slice(-2);
				secondsSpan.innerHTML = ("0" + t.seconds).slice(-2);
			}

			updateClock();
			var timeinterval = setInterval(updateClock, 1000);

		},

		playVideo: function() {

			var licenseKey = '487B0FAB-4D244F39-A986164A-3C134BD2';

			var btns = document.querySelectorAll('.btn-group');
			if(btns.length) {
				btns.forEach(btn => {
					lightGallery(btn, {
						selector: '.play-video',
						plugins: [lgVideo],
                        zoomFromOrigin: false,
						licenseKey: licenseKey,
						speed: 500,
					});
				});
			}

			var items = document.querySelectorAll('.about-imgs');
			if(items.length) {
				items.forEach(item => {
					lightGallery(item, {
						selector: '.about-media-item',
						plugins: [lgVideo],
                        zoomFromOrigin: false,
						licenseKey: licenseKey,
						speed: 500,
					});
				});
			}

		},

		//=== Counters ===\\
		counters: {

			init: function() {

				$(window).on("scroll load resize", function () {

					app.counters.spincrement();
	
				});

			},

			spincrement: function() {

				var counters = $(".spincrement-container");
	
				if(counters.length) {
	
					jQuery.each(counters, function() {
	
						var _this = $(this);
		
						if ( $(window).scrollTop() > _this.offset().top - ($(window).height() * 0.85) && !_this.hasClass("animated") ) {
		
							_this.addClass("animated");
		
							_this.find('.spincrement').spincrement({
								duration: 1500,
								leeway: 10,
								thousandSeparator: '',
								decimalPoint: ''
							});
							
						}
		
					});
	
				}
	
			},

		},

		//=== Progressbars ===\\
		progressbars: {

			init: function() {

				$(window).on("scroll load resize", function () {

					app.progressbars.linear();
					app.progressbars.circular();
	
				});

			},

			linear: function() {

				var progressbars = $(".progressbars");
	
				if(progressbars.length) {
	
					$.each(progressbars, function() {
	
						var _this = $(this);
		
						if ( $(window).scrollTop() > _this.offset().top - ($(window).height() * 0.85) && !_this.hasClass("animated") ) {
		
							_this.addClass("animated");
							var timeout = 0;
		
							$.each(_this.find('.progressbar-item'), function() {
		
								var counter = 0;
								var current = $(this).find('.progressbar-current');
								var value = parseInt( current.attr('data-progressbar-value') );
		
								setTimeout(function() {
									
									var customCounter = setInterval(function() {
										if(counter < value) {
											counter++;
											current.find('.progressbar-value').text(counter);
											current.css('--progressbar-value', counter + '%');
											if(counter > value/2) {
												current.find('.progressbar-percentage').addClass("visible");
											}
										} else {
											clearInterval(customCounter);
										};
									}, 10);
		
								}, timeout);
		
								timeout += 50;
		
							});
							
						}
		
					});
	
				}
	
			},

			circular: function() {

				var progressbars = $(".circle-progressbars");
	
				if(progressbars.length) {
	
					$.each(progressbars, function() {
	
						var _this = $(this);
		
						if ( $(window).scrollTop() > _this.offset().top - ($(window).height() * 0.85) && !_this.hasClass("animated") ) {
		
							_this.addClass("animated");
		
							$.each(_this.find('.cpb-item'), function() {
	
								var thickness = parseInt( $(this).attr('data-thickness') );
								var barColor = $(this).attr('data-color');
								var trackColor = getComputedStyle(document.querySelector('html')).getPropertyValue('--background-secondary-color');
								if(!barColor) {
									barColor = getComputedStyle(document.querySelector('html')).getPropertyValue('--accent-color');
								}
								if(_this.closest(".section").hasClass("section-bgc")) {
									trackColor = getComputedStyle(document.querySelector('html')).getPropertyValue('--background-color');
								}
								
								new EasyPieChart($(this).find('.cpbi-circle-inner')[0], {
									easing: 'easeOutElastic',
									delay: 2000,
									barColor: barColor,
									trackColor: trackColor,
									scaleColor: false,
									lineWidth: thickness,
									trackWidth: thickness,
									size: 200,
									lineCap: 'round',
									onStep: function(from, to, percent) {
										this.el.children[0].innerHTML = Math.round(percent);
									}
								});
		
							});
							
						}
		
					});
	
				}
	
				
	
			},

		},

		//=== Image Comparison ===\\
		imageComparison: function() {

			var containers = $(".compare-image-container");

			if(containers.length) {

				containers.each(function() {

					var _this = $(this),
						slider = _this.find(".compare-image-range");
	
					slider.on("input", function() {
						var val = $(this).val();
						_this.css('--value', val + "%");
					});
	
				});

			}

		},

		//=== Plugins ===\\

		lazyLoading: function() {

			var observer = lozad('.lazy');
			observer.observe();

		},

		device: function() {

			if( (device.mobile() || device.tablet()) && device.ios() ) {
				var tempCSS = $('a').css('-webkit-tap-highlight-color');
				$('main, .main-inner').css('cursor', 'pointer')
						 .css('-webkit-tap-highlight-color', 'rgba(0, 0, 0, 0)');
				$('a').css('-webkit-tap-highlight-color', tempCSS);
			}

		},

		popUp: function() {

			$('.open_popup').popup({
				transition: 'all 0.4s',
				color: '#000000',
				opacity: 0.8
			});
			$('.popup_autoopen').popup({
				transition: 'all 0.4s',
				color: '#000000',
				autoopen: true,
				opacity: 0.8
			});

		},

		carusels: function() {
			
			var reviewsCaruselTh = $('.reviews-carusel-th');
			reviewsCaruselTh.flickity({
				imagesLoaded: true,
				lazyLoad: true,
				pageDots: false,
				adaptiveHeight: true,
				fade: true,
				prevNextButtons: false
			});

			$('.reviews-thumb-item').on('click', function() {
				var _this = $(this),
					index = _this.index();
				reviewsCaruselTh.flickity( 'select', index );
				_this.addClass("active").siblings().removeClass("active");
			});


			$('.pitem-carusel-main').flickity({
				pageDots: false,
				imagesLoaded: true,
				lazyLoad: 1,
				prevNextButtons: true
			});
			$('.pitem-carusel-thumb').flickity({
				asNavFor: '.pitem-carusel-main',
				imagesLoaded: true,
				lazyLoad: 5,
				prevNextButtons: true,
				contain: true,
				pageDots: false
			});

		},

		isotopeProjects: function() {

			var items = $(".pitems");

			$.each(items, function() {

				var item = $(this);
				var li = item.parent().find('.pitem-nav-list li');

				if(li.length) {

					item.isotope({
						itemSelector: '.pitem-col'
					});
		
					li.on('click', function() {
						var _this = $(this),
							selector = _this.data('filter');
						
						_this.addClass("active").siblings().removeClass("active");
						item.isotope({
							filter: selector
						});
					});

				}

			});	

		},

		lightGallery: function() {

			var galleries = document.querySelectorAll('.gallery-container');
			if(galleries.length) {
				galleries.forEach(galery => {
					lightGallery(galery, {
						selector: '.gallery-col',
						plugins: [lgZoom, lgThumbnail, lgVideo],
						zoomFromOrigin: false,
						exThumbImage: 'data-external-thumb-image',
						licenseKey: '487B0FAB-4D244F39-A986164A-3C134BD2',
						speed: 500,
					});
				});
			}

		},

		isotopeGallery: function() {

			var container = $("#gallery-container");

			container.isotope({
				itemSelector: '.gallery-col'
			});

			$('.gallery-nav-list li').on('click', function() {
				var _this = $(this),
					selector = _this.data('filter');
				
				_this.addClass("active").siblings().removeClass("active");
				container.isotope({
					filter: selector,
				});
			});

		},

		isotopeGalleryMasonry: function() {

			var container = $('.gallery-masonry-container');
			container.isotope({
				itemSelector: '.gallery-col',
				percentPosition: true,
				masonry: {
					columnWidth: '.gallery-col-sizer'
				}
			});

			/*$('.gallery-masonry-nav-list li').on('click', function() {
				var _this = $(this),
					selector = _this.data('filter');
				
				_this.addClass("active").siblings().removeClass("active");
				container.isotope({
					filter: selector,
				});
			});*/

		},

		isotopeCareers: function() {

			var $grid = $('#careers-container').isotope();

			$('.careers-filter-list').on('click', 'li', function() {
				var filterValue = $(this).attr('data-filter');
				$('.careers-filter-list li').removeClass("active");
				$(this).addClass("active");
				$grid.isotope({ filter: filterValue });
			});

		},

		debounce: function(func) {

            var timer;

            return function(event) {
                if(timer) clearTimeout(timer);
                timer = setTimeout(func, 100, event);
            };

        },
		
	}
 
	app.init();
 
}());