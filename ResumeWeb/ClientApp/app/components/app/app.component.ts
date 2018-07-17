import { Component } from '@angular/core';
import { Globals } from '../../globals';
import { routerTransition } from '../../router.animations';

@Component({
    selector: 'app',
    animations: [routerTransition],
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private globals: Globals) {

    }

    public getState(outlet: any) {
        return outlet.activatedRoute.routeConfig.path;
    }
}
