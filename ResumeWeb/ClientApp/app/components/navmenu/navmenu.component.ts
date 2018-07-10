import { Component, HostListener } from '@angular/core';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {

    show: boolean = false;

    toggleCollapse(): void {
        this.show = !this.show;
    }

    @HostListener('window:resize')
    onResize() {
        if (this.show)
            this.show = false;
    }
}
