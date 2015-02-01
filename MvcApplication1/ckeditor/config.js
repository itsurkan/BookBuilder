/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (e) {
    e.toolbarGroups = [
            { name: "mode"},
            { name: "basicstyles", groups: ["basicstyles", "cleanup"] },
            { name: "paragraph", groups: ["list", "blocks", "align"] },
            { name: "clipboard", groups: ["clipboard", "undo"] },
            { name: "editing", groups: ["selection", "spellchecker"] }, //"find", 
            //  { name: "forms" },
            { name: "links" },
            { name: "insert" },
            { name: "styles" },
            { name: "colors" },
            { name: "tools"},
            { name: "others" }
    ],

        e.removeButtons = "Cut,Copy,Paste,Undo,Redo,Anchor,Underline,Strike,Subscript,Superscript,Div",
        e.removeDialogTabs = "link:advanced",
    //e.removePlugins = "autogrow",
        e.removePlugins = 'elementspath',
        e.resize_enabled = false,
        e.skin = 'moonocolor';
    e.extraPlugins = 'codemirror,codeTag,textselection',//codesnippetgeshi
        e.height = '88%';
    // e.allowedContent = 'p';
};

