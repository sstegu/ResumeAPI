import { Component, ChangeDetectorRef } from '@angular/core';
import { Globals } from '../../globals';
import { Observable } from 'rxjs/Observable';
import { OnInit, OnDestroy } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnDestroy {


    private showWaiting: boolean = false;


    ngOnDestroy(): void {
        this.globals.waiting$.unsubscribe();
    }

    constructor(private globals: Globals, private changeDetectorRef: ChangeDetectorRef) {
        console.log('app constructor');
        this.globals.waiting$.subscribe((val) => {
            console.log('showwaiting changed ' + val);
            this.showWaiting = val;

        });

    }
}
