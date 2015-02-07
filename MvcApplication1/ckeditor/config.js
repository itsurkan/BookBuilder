/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (e) {
    e.toolbarGroups = [
            { name: "mode" },
            { name: "basicstyles", groups: ["basicstyles", "cleanup"] },
            { name: "paragraph", groups: ["list", "blocks", "align"] },
            { name: "clipboard", groups: ["clipboard", "undo"] },
            { name: "editing", groups: ["selection", "spellchecker"] }, //"find", 
            //  { name: "forms" },
            { name: "links" },
            { name: "insert" },
            { name: "styles" },
            { name: "colors" },
            { name: "tools" },
            { name: "others" }
        ],
        e.removeButtons = "Cut,Copy,Paste,Undo,Redo,Anchor,Underline,Strike,Subscript,Superscript,Div,Code",
        e.removeDialogTabs = "link:advanced",
        e.removePlugins = 'elementspath',
        e.resize_enabled = false,
        e.skin = 'moonocolor',
        e.toolbarCanCollapse = false,


        //e.tool = 'body{background:#FFFFFF;text-align:left;font-size:0.8em;}',
        //e.tool='body{padding: 1px;margin: 0;background-color: #ffffff;}',

	    e.enterMode = CKEDITOR.ENTER_P,
	    e.shiftEnterMode = CKEDITOR.ENTER_BR,
	    e.colorButton_enableMore = true,
  	    e.bodyId = 'content',
	    e.entities = false,
	    e.forceSimpleAmpersand = false,
	    e.fontSize_defaultLabel = '14px',
	    e.font_defaultLabel = 'Arial',
	    e.emailProtection = 'encode',
	    e.toolbarLocation = 'top',
	    e.browserContextMenuOnCtrl = false,

        e.addCss = '.cke_editable{border-color: #FFFFFF;}',
      



        e.extraPlugins = 'codesnippet,codemirror,codeTag,textselection,autogrow', //save widget lite lineutils
        e.autoGrow_minHeight = 200;
        e.autoGrow_maxHeight = 600;
        e.autoGrow_bottomSpace = 50;

        e.magicline_color = 'blue',

        e.codeSnippet_theme = 'magula',
        e.codeSnippet_languages = {
        javascript: 'JavaScript',
        java: 'Java',
        css: 'CSS',
        html: 'HTML',
        php: 'PHP',
        cpp: 'C++',
        cs: 'C#',
        python: 'Python',
        sql: 'SQL',
        xml: 'XML'},

        e.height = '88%';
    // e.allowedContent = 'p';
};

