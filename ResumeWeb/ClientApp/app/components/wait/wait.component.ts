import { Component } from '@angular/core';
import { Globals } from '../../globals';

@Component({
    selector: 'wait',
    styleUrls: ['wait.component.css'],
    template: `
        <div *ngIf="globals.waiting" class="alert alert-info">Please wait...</div>
    `
})
export class WaitComponent {

    constructor(private globals: Globals) {

    }

}
