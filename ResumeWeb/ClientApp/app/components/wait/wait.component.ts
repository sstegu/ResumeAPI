import { Component } from '@angular/core';
import { transition, state, style, animate, trigger } from '@angular/animations';
import { Globals } from '../../globals';

@Component({
    animations: [trigger('waitState', [
        state('true', style({
            opacity: 1,
            display: 'inline'
        })),
        state('false', style({
            opacity: 0,
            display: 'none'
        })),
        transition('*<=>*', animate(600))
    ])
    ],
    selector: 'wait',
    styleUrls: ['wait.component.css'],
    template: `
        <div [@waitState]="globals.waiting" class="waitOverlay"><div class="wait alert alert-info">Please wait...</div></div>
    `
})
export class WaitComponent {

    constructor(public globals: Globals) {

    }

}
