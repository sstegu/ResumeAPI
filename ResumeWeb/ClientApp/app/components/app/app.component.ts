import { Component } from '@angular/core';
import { Globals } from '../../globals';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private globals: Globals) {

    }

}
