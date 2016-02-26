/// <reference path="jquery-1.8.2.js" />
/// <reference path="jquery.validate.js" />
/// <reference path="jquery.ajaxform.js" />

$(function () {
    
    $("#createAccount form").validate({
        rules: {
            Username: "required",
            Password: "required",
            ConfirmPassword: {
                required: true,
                equalTo: "#Password"
            },
            Email: {
                required: true,
                email: true
            }
        },
        messages: {
            Username: "Username is required",
            Password: "Password is required",
            ConfirmPassword: {
                required: "Confirm Password is required",
                equalTo: "Confirm Password must match Password"
            },
            Email: {
                required: "Email is required",
                email: "A valid email is required"
            }
        }
    });

    var styleTable = function () {
        $("tbody tr:even").css("backgroundColor", "#EEE");
    };
    styleTable();

    $(document)
        .ajaxStart(function () {
            $("img[src$='wait.gif']").show();
        })
        .ajaxStop(function () {
            $("img[src$='wait.gif']").hide();
        })
        .ajaxSuccess(function () {
            styleTable();
        });

    $(".reviews tbody tr")
        .click(function () {
            var href = $(this).find("a").attr("href");
            if (href) {
                window.location = href;
            }
        })
        .on("mouseover mouseout", function () {
            $(this).toggleClass("highlight");
        });

    $(".movies")
        .on("click", "tbody tr", function () {
            var me = $(this);
            var href = me.find("a").attr("href");
            if (href) {
                $("#movieDetails").load(href, function () {
                    $(this)
                        .slideDown()
                        .append(
                            $("<button>Close</button>")
                                .click(function () {
                                    $("#movieDetails")
                                        .slideUp();
                                })
                        );
                });
            }
        })
        .on("mouseover mouseout", "tbody tr", function () {
            $(this).toggleClass("highlight");
        })
        .on("mouseover", "tbody tr", function () {
            var name = $(this).find("a:first").text();
            var url = '/Poster/Index/' + name;
            var img = $("<img>", { src: url, title: name });
            $("#imgContainer").empty().append(img);
        });

    $(".movies")
        .on("click", "table a", function (e) {
            e.preventDefault();
        });

    $("#movieSearch form, #reviewSearch form").ajaxForm("#searchResults");

    $("#searchByGenre #genreID").change(function () {
        $("#searchByGenre img").show();
        $("#searchByGenre :submit").trigger("click");
    });
    $("#searchByGenre :submit").hide();

    $("#movieSearch :text").triggerHandler("keydown");

    $("#loginButton")
        .click(function () {
            var uid = $("#Username");
            var pwd = $("#Password");
            if ($.trim(uid.val()) === "" || $.trim(pwd.val()) === "") {
                $("#errorDialog").show();
                return false;
            }
        });

    $("#closeErrorDialog").click(function () {
        $("#errorDialog").slideUp();
    });

    $(":text:visible:first").focus();
});
