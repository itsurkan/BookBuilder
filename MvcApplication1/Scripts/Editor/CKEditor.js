    CKEDITOR.replace('editor', {
        //language: 'ru',
        magicline_color: 'blue',
        fullPage: false,
        uiColor: '#dfdfdf',
        //resize_enabled: 'false',
        removePlugins: 'elementspath',


        //   allowedContent:
        //'h1 h2 h3 p blockquote strong em;' +
        //'a[!href];' +
        //'img(left,right)[!src,alt,width,height];' +
        //'table tr th td caption;' +
        //'span{!font-family};' +'' +
        //'span{!color};' +
        //'span(!marker);' +
        //'del ins',
        on: {
            instanceReady: function(evt) {
                var editor = evt.editor;
                // var data = editor.getData();
                /// alert(data);
                //editor.filter.check('h1'); // -> false
            }
        }
    });
CKEDITOR.on('change', function(evt) {
    // getData() returns CKEditor's HTML content.
    alert(   evt.editor.getData().length);
});

CKEDITOR.on('instanceReady', function (ev) {
    // Show the editor name and description in the browser status bar.
    document.getElementById('eMessage').innerHTML = 'Instance <code>' + ev.editor.name + '<\/code> loaded.';

    // Show this sample buttons.
    document.getElementById('eButtons').style.display = 'block';
});

window.onscroll = scroll;

function scroll(event) {
    //document.getElementById("editor").scroll(event);
    var editor = CKEDITOR.instances.editor;
    editor.contentWindow.scrollTo(0, 3);

};

function InsertHTML() {
    // Get the editor instance that we want to interact with.
    var editor = CKEDITOR.instances.editor;
    var value = document.getElementById('htmlArea').getData;

    // Check the active editing mode.
    if (editor.mode == 'wysiwyg') {
        // Insert HTML code.
        // http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-insertHtml
        editor.insertHtml(value);
    }
    else
        alert('You must be in WYSIWYG mode!');
}
