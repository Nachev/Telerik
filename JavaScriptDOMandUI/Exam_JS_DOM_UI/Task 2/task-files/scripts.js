$.fn.gallery = function(columns) {
    var $this = $(this),
        $galleryList = $this.find('.gallery-list'),
        $selected = $this.find('.selected'),
        col = columns || 4,
        IMG_WIDTH = 260; // Image 250 + margin 10;

    function changeCurrentZoomed() {
        var $self = $(this),
            $previousImage = $self.prev().find('img'),
            $currentImage = $self.find('img'),
            $nextImage = $self.next().find('img'),
            source = $currentImage.attr('src'),
            $currentSelectedContainer = $selected.find('.current-image');

        if ($self.parent().hasClass('disabled-background')) {
            return;
        }

        $galleryList.addClass('blurred disabled-background');
        $currentSelectedContainer
            .prev()
            .find('img')
            .attr('src', $previousImage.attr('src'))
            .attr('data-info', $previousImage.data('info').toString());
        $currentSelectedContainer
            .find('img')
            .attr('data-info', $currentImage.data('info').toString())
            .attr('src', source);
        $currentSelectedContainer
            .next()
            .find('img')
            .attr('src', $nextImage.attr('src'))
            .attr('data-info', $nextImage.data('info').toString());
        $selected.show();
    }

    $this.addClass('gallery');
    $selected.hide();
    $this.width(col * IMG_WIDTH);
    $this.on('click', '.image-container', changeCurrentZoomed);
    $selected.on('click', 'div', function() {
        var $self = $(this),
            key = $selected.find('.current-image img').data('info');

        if ($self.hasClass('current-image')) {
            $galleryList.removeClass('blurred disabled-background');
            $selected.hide();
        } else if ($self.hasClass('previous-image')) {
            $self.find('img')
                .attr('src',
                    $galleryList.find('img[data-info=' + (key - 2) + ']').attr('src'))
                .attr('data-info', (key - 2).toString());

            $selected.find('#current-image')
                .attr('src',
                    $galleryList.find('img[data-info=' + (key - 1) + ']').attr('src'))
                .attr('data-info', (key - 1).toString());

            $selected.find('#next-image')
                .attr('src',
                    $galleryList.find('img[data-info=' + key + ']').attr('src'))
                .attr('data-info', key.toString());
        } else if ($self.hasClass('next-image')) {
            $self.find('img')
                .attr('src',
                    $galleryList.find('img[data-info=' + (key + 2) + ']').attr('src'))
                .attr('data-info', (key - 2).toString());

            $selected.find('#current-image')
                .attr('src',
                    $galleryList.find('img[data-info=' + (key + 1) + ']').attr('src'))
                .attr('data-info', (key - 1).toString());

            $selected.find('#previous-image')
                .attr('src',
                    $galleryList.find('img[data-info=' + key + ']').attr('src'))
                .attr('data-info', key.toString());
        }
    });
};