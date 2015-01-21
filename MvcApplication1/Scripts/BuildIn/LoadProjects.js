        app.data = new classes.Data({ "gitlab_url": "https://git.atlas.oreilly.com", "github_url": "https://api.github.com", "asset_url": "https://d32xvvb5lxy7xi.cloudfront.net", "user": { "nickname": "demo_book", "avatar": "https://secure.gravatar.com/avatar/b5a4cc2539e3d81d9944eaf07e3163eb?s=80", "gitlab_token": "v8zZzqhx8vUcpy_9BDkK", "gitlab_id": 1391, "authentication_token": "Q7qoy7e3ajd6aJBM6153", "email": "tsurkan_i@mail.ru", "uid": null, "id": 1317 }, "permissions": { "admin": false } });
        $(function () {
            app.flash = new classes.FlashView();
            $("#main").prepend(app.flash.render().el);

            var feedback_data = $.extend(true, {}, app.data)
            feedback_data.attributes.user = _.omit($.extend(true, {}, app.data.get('user')), ['gitlab_token', 'authentication_token'])

            app.feedback = new classes.FeedbackModalView({
                data: feedback_data,
                tagName: 'li',
                buttonTag: 'a',
                label: 'Feedback',
                classes: [""]
            })
            $('.navbar ul.nav').first().append(app.feedback.render().el)

            var currentView = window.classes["HomeIndexView"];
            if (currentView) app.main = new currentView({ el: "body" });
        });

        // segmentio
window.analytics || (window.analytics = []),
window.analytics.methods = ["identify", "track", "trackLink", "trackForm", "trackClick", "trackSubmit", "page", "pageview", "ab", "alias", "ready", "group", "on", "once", "off"],

window.analytics.factory = function (a) {
    return function () {
        var t = Array.prototype.slice.call(arguments); return t.unshift(a),
            window.analytics.push(t), window.analytics
    }
};

for (var i = 0; i < analytics.methods.length; i++)
{ var method = analytics.methods[i]; analytics[method] = analytics.factory(method) }

window.analytics.load = function(a) {
    var t = document.createElement("script");
    t.type = "text/javascript",
    t.async = !0,
    t.src = ("https:" === document.location.protocol ? "https://" : "http://") + "d2dq2ahtl5zl1z.cloudfront.net/analytics.js/v1/" + a + "/analytics.min.js";
    var n = document.getElementsByTagName("script")[0]; n.parentNode.insertBefore(t, n)
},

window.analytics.SNIPPET_VERSION = "2.0.5",
window.analytics.load("37pq6ln7ck"),
window.analytics.page();