(function() {

	"use strict";
  
	var app = {
		
		init: function() {
            
			this.setUpListeners();
            app.sliderRange("#filter-by-price", 8, 54);

            this.carusels();

		},
 
		setUpListeners: function() {

            $(".cpq-btn").on("click", this.cardQuantity);

            $(".card-page-reviews > a").on("click", this.cardPageToReviews);

            $("#ship-to-different-address-checkbox").on("click", this.shipToDifferentAddressToggle);

            $(".st-payment-method input").on("change", this.paymentMethodToggle)

        },

        cardQuantity: function() {

            var _this = $(this),
                input = _this.parent().find("input"),
                value = parseInt(input.val());

            if(value < 1) {

                input.val(1);

            } else {

                if(_this.hasClass("cpq-plus")) {

                    input.val(value+1);
    
                } else {
    
                    if(value > 1) { input.val(value-1); }
    
                }

            }

        },

        cardPageToReviews: function(e) {
            e.preventDefault();

            $(".tabs-reviews-link").add(".tabs-reviews-item").addClass("active").siblings().removeClass("active");
            if($(this).parent().hasClass("card-page-reviews-scroll")) {
                console.log($('#product-tabs').offset().top);
                $("html, body").animate({ scrollTop: $('#product-tabs').offset().top - $(".header-fixed").outerHeight() - 20 }, 1000);
            }

        },

        shipToDifferentAddressToggle: function() {

            var sa = $(".shipping_address");

            if( $("#ship-to-different-address-checkbox:checked").length === 1 ) {

                sa.slideDown();

            } else {
                
                sa.slideUp();

            }

        },

        paymentMethodToggle: function() {

            var _this = $(this),
                item = _this.closest("li"),
                desc = item.find(".payment-method-desc"),
                delay = 250;

            item.siblings().find(".payment-method-desc").slideUp(delay);
            desc.slideDown(delay);

        },

        sliderRange: function(target, min, max) {

            var _this = $(target),
                container = _this.closest(".slider-range-outer"),
                val1 = container.find(".sri1"),
                val2 = container.find(".sri2");

            _this.slider({
                range: true,
                min: min,
                max: max,
                values: [ min, max ],
                slide: function( event, ui ) {
                    val1.text(ui.values[ 0 ]);
                    val2.text(ui.values[ 1 ]);
                }
            });

            val1.text(_this.slider( "values", 0 ));
            val2.text(_this.slider( "values", 1 ));

        },

        carusels: function() {

            $('.product-carusel-main').flickity({
				pageDots: false,
				imagesLoaded: true,
				lazyLoad: 1,
                cellSelector: '.pcm-item',
				prevNextButtons: false
			});
			$('.product-carusel-thumb').flickity({
				asNavFor: '.product-carusel-main',
				imagesLoaded: true,
				lazyLoad: 4,
				prevNextButtons: false,
                cellAlign: 'left',
				contain: true,
				pageDots: false
			});

        }
		
	}
 
	app.init();
 
}());