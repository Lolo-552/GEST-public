// TinyMCE CMS Starter Config
// Quick start video - https://www.youtube.com/watch?v=cbkrZMbVF60

tinymce.init({
    // Select the element(s) to add TinyMCE to using any valid CSS selector
    selector: 'textarea.editme',
    // Tip - To keep TinyMCE lean, only include the plugins you need.
    plugins: `advlist anchor autosave image link lists media searchreplace table template visualblocks wordcount`,
    // Configure the toolbar so it fits your app. There are many
    // different configuration options available:
    // https://www.tiny.cloud/docs/tinymce/6/toolbar-configuration-options/
    toolbar: 'undo redo | styles | bold italic underline strikethrough | align | table link image media pageembed | bullist numlist outdent indent | spellcheckdialog a11ycheck code',

    // The Accessibility Checker plugin offers extensive controls over which
    // level of compliance to test against and which rules to enforce.
    // https://www.tiny.cloud/docs/tinymce/6/a11ychecker/
    a11ychecker_level: 'aaa',

    // Configure the style menu and define available formats
    // Here, we have defined a medium sized image format as an example.
    // There is a lot more you can do with formats:
    // https://www.tiny.cloud/docs/tinymce/6/filter-content/
    style_formats: [
        { title: 'Heading 1', block: 'h1' },
        { title: 'Heading 2', block: 'h2' },
        { title: 'Paragraph', block: 'p' },
        { title: 'Blockquote', block: 'blockquote' },
        { title: 'Image formats' },
        { title: 'Medium', selector: 'img', classes: 'medium' },
    ],

    // Turn off manual resizing of images as we want to control image sizes
    // using the formats previously specified.
    // https://www.tiny.cloud/docs/tinymce/6/content-behavior-options/#object_resizing
    object_resizing: false,

    // TinyMCE offers a wide range of options to control what classes, styles
    // and attributes are allowed in the content. All other classes will be
    // filtered out.
    // https://www.tiny.cloud/docs/tinymce/6/content-filtering/#valid_classes
    valid_classes: {
        'img': 'medium',
        'div': 'related-content'
    },

    // Enable image fig captions
    // https://www.tiny.cloud/docs/tinymce/6/image/#image_caption
    image_caption: true,

    // Templates is useful for when users need to insert repeatable content,
    // for example a related content block.
    // https://www.tiny.cloud/docs/tinymce/6/template/
    templates: [
        {
            title: 'Related content',
            description: 'This template inserts a related content block',
            content: '<div class="related-content"><h3>Related content</h3><p><strong>{$rel_lede}</strong> {$rel_body}</p></div>'
        }
    ],

    // This option makes it easy to inject dynamic content into the template.
    template_replace_values: {
        rel_lede: 'Lorem ipsum',
        rel_body: 'dolor sit amet...',
    },

    // Specifies the dynamic content inside the insert template dialog preview
    template_preview_replace_values: {
        rel_lede: 'Lorem ipsum',
        rel_body: 'dolor sit amet...',
    },

    // Prevent editing of the related content block by making the whole
    // block noneditable.
    // https://www.tiny.cloud/docs/tinymce/6/content-behavior-options/#noneditable_class
    noneditable_class: 'related-content',

    // TinyMCE supports multilingual content. By defining the language
    // not only are you helping with accessibility, the spellchecker plugin
    // also switches language.
    // https://www.tiny.cloud/docs/tinymce/6/content-localization/#content_langs
    content_langs: [
        { title: 'English (US)', code: 'en_US' },
        { title: 'Polish', code: 'pl' }
    ],

    // Specify the height of the editor, including toolbars and the statusbar.
    // https://www.tiny.cloud/docs/tinymce/6/customize-ui/#changing-editor-height-and-width
    height: 540,

    // The following css will be injected into the editor, extending
    // the default styles.
    // In a real world scenario, it's recommended to use the content_css
    // option to load a separate CSS file. This makes editing easier too.
    // https://www.tiny.cloud/docs/tinymce/6/add-css-options/
    /*content_style: `
                              img{
                                width: 100%;
                             max-width: 600px;
                              }
                              img.medium {
                                max-width: 50%;
                              }
                            `
     */
    images_upload_url: '/Home/UploadImage',
    // Next step: Check out Tiny Drive for easy cloud storage of your users'
    // images and media. Integrates seamlessly with TinyMCE.
    // https://www.tiny.cloud/drive/
});