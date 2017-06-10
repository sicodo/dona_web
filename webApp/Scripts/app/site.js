"use strict";

var app = {};

$.fn.serializeFormJSON = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};

function showTopMenu() {
    if (!app.menu_bottom_value) {
        app.menu_bottom_value = app.menu_top.offset().top;
    }
    var y = $(this).scrollTop()
    if (y > app.menu_bottom_value) {
        if (!app.page.hasClass("top-menu-fixed")) {
            app.page.addClass("top-menu-fixed");
            app.header.css("width", app.page_width);
        }
    } else {
        if (app.page.hasClass("top-menu-fixed")) {
            app.page.removeClass("top-menu-fixed");
            app.header.css("width", "auto");
        }
    }
}
//This event fires immediately when the bootstrap slide instance method is invoked.
function progressBarCarousel() {
    app.banner.bar.css({ width: app.banner.percent + '%' });
    app.banner.percent = app.banner.percent + 0.5;
    if (app.banner.percent >= 100) {
        app.banner.percent = 0;
        app.banner.container.carousel('next');
    }
}

function attachCarouselProgressBar() {
    app.banner = {
        percent: 0,
        interval: 30,
        barInterval: 0,
        container: $('#banner_container'),
        bar: $('.transition-timer-carousel-progress-bar')
    };

    console.log(app);

    $('.carousel-indicators li, .carousel-control').click(function () { app.banner.bar.css({ width: 0.5 + '%' }); });

    app.banner.container.carousel({//initialize
        interval: false,
        pause: true
    }).on('slide.bs.carousel', function () { app.banner.percent = 0; });

    app.banner.barInterval = setInterval(progressBarCarousel, app.banner.interval);//set interval to progressBarCarousel function
    if (!(/Mobi/.test(navigator.userAgent))) {//tests if it isn't mobile
        app.banner.container.hover(function () {
            clearInterval(app.banner.barInterval);
        },
                function () {
                    app.banner.barInterval = setInterval(progressBarCarousel, app.banner.interval);
                }
        );
    }
}

function popupContent(id, content_type) {
    $.get(app.url.getContent, { id: id, content_type: content_type }, function (response) {
        showPopup({
            title: response.title,
            content: response.content
        });
    });
}

function showCourse(id_course) {
    popupContent(id_course, app.content_types.course);
}

function showSchedule() {
    $.get(app.url.getSchedule, null, function (schedule) {
        showPopup({
            title: 'Lịch khai giảng',
            content: schedule
        });
    });
}

function popUpContentEdit(options) {
    if (!app.popupForm) {
        app.popup = { container: $("#popup_container") };
        if (app.popup.container.size() == 0) {
            $.get(app.url.popup, function (response_data) {
                app.popup.container = $(response_data).appendTo("body");

                showPopup(options);
            });
        }        
    }

    if (app.popup.container.size() > 0) {
        if (!app.popup.title) {
            app.popup.title = app.popup.container.find(".modal-title");
        }
        if(!app.popup.body){
            app.popup.body = app.popup.container.find(".modal-body");
        }

        if (options) {
            if (options.title) {
                app.popup.title.html(options.title);
            }
            if (options.content) {
                app.popup.body.html(options.content);
            }
        }
    }

    app.popup.container.modal(options);
}

function showPopup(options) {
    if (!app.popup) {
        app.popup = { container: $("#popup_container") };
        if (app.popup.container.size() == 0) {
            $.get(app.url.popup, function (response_data) {
                app.popup.container = $(response_data).appendTo("body");

                showPopup(options);
            });
        }
    }

    if (app.popup.container.size() > 0) {
        if (!app.popup.title) {
            app.popup.title = app.popup.container.find(".modal-title");
        }
        if (!app.popup.body) {
            app.popup.body = app.popup.container.find(".modal-body");
        }

        if (options) {
            if (options.title) {
                app.popup.title.html(options.title);
            }
            if (options.content) {
                app.popup.body.html(options.content);
            }
        }
    }

    app.popup.container.modal(options);
}

function post(url, param, callback) {
    $.ajax({
        type: "POST",
        async: true,
        url: url,
        data: param,
        success: callback
    });
}

function init() {
    app.page = $("#page-wrapper");
    app.menu_top = $("#page-wrapper #menu_top");
    app.header = $("#page-wrapper #page-header");
    app.page = $("#page-wrapper");
    app.menu_bottom_value = 0;
    app.page_width = app.page.width();

    app.page.find(".datepicker").datetimepicker({
        format: "dd/MM/yyyy"
    });


    // default configs
    //$.fn.datepicker.defaults.format = "dd/mm/yyyy";
}

jQuery(document).ready(function ($) {
    init();

    $(window).scroll(function () {
        showTopMenu();
    });

    showTopMenu();    
});

