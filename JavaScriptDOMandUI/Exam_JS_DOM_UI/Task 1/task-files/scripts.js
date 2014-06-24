/*jslint browser: true*/
function createImagesPreviewer(selector, items) {
    'use strict';
    var container = document.querySelectorAll(selector)[0],
        imageZoomed = null,
        titleZoomed = null,
        imageMenu = null,
        titleMenu = null,
        zoomContainer = null,
        imageClone = null,
        titleClone = null,
        zoomElementClone = null,
        menuContainer = null,
        menuElement = null,
        zoomElement = null,
        menuElementClone = null,
        filter = null,
        i = 0,
        len = 0;

    function filterPhotos(ev) {
        var value = this.value,
            menuItems = null,
            title = null;

        menuItems = document.getElementsByClassName('menu-box');
        for (i = menuItems.length - 1; i >= 0; i--) {
            title = menuItems[i].getElementsByTagName('h2')[0].innerText;
            if (title.toLowerCase().indexOf(value.toLowerCase()) >= 0) {
                menuItems[i].style.display = '';
            } else {
                menuItems[i].style.display = 'none';
            }
        }
    }

    function generateFilter() {
        var formElement = document.createElement('form'),
            formTitle = document.createElement('h3'),
            formInput = document.createElement('input');

        formTitle.innerText = 'Filter';
        formTitle.style.fontSize = '1em';
        formTitle.style.fontWeight = '400';
        formTitle.style.margin = '0';
        formTitle.style.textAlign = 'center';
        formElement.appendChild(formTitle);

        formInput.style.width = '100%';
        formInput.addEventListener('input', filterPhotos, false);
        formElement.appendChild(formInput);
        formElement.style.width = '90%';
        formElement.style.margin = '0 auto';

        return formElement;
    }

    function initializeZoomedElements() {
        imageZoomed = document.createElement('img');
        imageZoomed.style.borderRadius = '15px';
        imageZoomed.setAttribute('width', '100%');
        titleZoomed = document.createElement('h2');
        titleZoomed.style.textAlign = 'center';
        titleZoomed.style.fontSize = '2em';
        titleZoomed.style.fontWeight = '800';
        zoomElement = document.createElement('div');
        zoomElement.style.width = '90%';
        zoomElement.style.margin = '0 auto';
        zoomElement.className = 'zoom-box';
        zoomElement.style.display = 'none';
        zoomContainer = document.createElement('div');
        zoomContainer.style.width = '70%';
        zoomContainer.style.float = 'left';
    }

    function generateZoomedElement(item) {
        imageClone = imageZoomed.cloneNode();
        imageClone.setAttribute('src', item.url);
        titleClone = titleZoomed.cloneNode();
        titleClone.innerText = item.title;
        zoomElementClone = zoomElement.cloneNode();
        zoomElementClone.appendChild(titleClone);
        zoomElementClone.appendChild(imageClone);
        zoomElementClone.id = item.title;
        zoomContainer.appendChild(zoomElementClone);
    }

    function initializeMenuElements() {
        filter = generateFilter();
        imageMenu = document.createElement('img');
        imageMenu.style.borderRadius = '15px';
        imageMenu.setAttribute('width', '95%');
        titleMenu = document.createElement('h2');
        titleMenu.style.textAlign = 'center';
        titleMenu.style.margin = '0';
        titleMenu.style.fontSize = '1em';
        titleMenu.style.fontWeight = '800';
        menuElement = document.createElement('div');
        menuElement.className = 'menu-box';
        menuElement.style.width = '90%';
        menuElement.style.margin = '2px auto';
        menuElement.style.padding = '0 7%';
        menuContainer = document.createElement('div');
        menuContainer.style.width = '30%';
        menuContainer.style.height = '100%';
        menuContainer.style.overflow = 'scroll';
        menuContainer.style.overflowX = 'hidden';
        menuContainer.style.float = 'right';
        menuContainer.appendChild(filter);
    }

    function generateMenuElement(item) {
        imageClone = imageMenu.cloneNode();
        imageClone.setAttribute('src', item.url);
        titleClone = titleMenu.cloneNode();
        titleClone.innerText = item.title;
        menuElementClone = menuElement.cloneNode();
        menuElementClone.appendChild(titleClone);
        menuElementClone.appendChild(imageClone);
        menuElementClone.addEventListener('mouseover', eventHandler, false);
        menuElementClone.addEventListener('mouseout', eventHandler, false);
        menuElementClone.addEventListener('click', eventHandler, false);
        menuContainer.appendChild(menuElementClone);
    }

    function eventHandler(ev) {
        var self = this,
            sbilings = null,
            zoom = null,
            currentClassName = null,
            i = 0;

        switch (ev.type) {
            case 'mouseover':
                self.style.backgroundColor = '#CCCCCC';
                break;
            case 'mouseout':
                self.style.backgroundColor = '#FFFFFF';
                break;
            case 'click':
                zoom = document.getElementById(self.getElementsByTagName('h2')[0].innerText);
                zoom.className += ' selected';
                zoom.style.display = '';
                sbilings = zoom.parentNode.childNodes;
                for (i = sbilings.length - 1; i >= 0; i--) {
                    if (sbilings[i] !== zoom) {
                        currentClassName = sbilings[i].className;
                        currentClassName.replace(/selected/g, "");
                        sbilings[i].style.display = 'none';
                    }
                }

                break;
        }
    }

    container.style.width = '600px';
    container.style.height = '400px';

    initializeZoomedElements();
    initializeMenuElements();

    for (i = 0, len = items.length; i < len; i += 1) {
        generateZoomedElement(items[i]);
        generateMenuElement(items[i]);
    }

    // Show first zoomed element.
    zoomContainer.firstChild.className += ' zoomed';

    zoomContainer.getElementsByClassName("zoomed")[0].style.display = '';
    container.appendChild(zoomContainer);
    container.appendChild(menuContainer);
}