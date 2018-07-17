import { Component, Input } from '@angular/core';
import { ApiService } from '../../api';
import { Globals } from '../../globals';
import { trigger, state, style, animate, transition } from '@angular/animations';

@Component({
   
    selector: 'my-footer',
    styleUrls: ['footer.component.css'],
    templateUrl: './footer.component.html',
    providers: [ApiService]
})
export class FooterComponent {
    public email: string;
    public github: string = 'https://github.com/sstegu';
    public phone: string;
    public footerState: string = 'in';
    constructor(private api: ApiService, public globals: Globals) {
        this.api.GetCandidate('1').subscribe(response => {
            if (response.ok) {
                var data = response.json();
                this.phone = data['phone'];
                this.email = data['email'];
            }
        }, error => {
            this.email = 'sashastegu@gmail.com';
        }, () => {
            this.footerState = 'out';
        });
    }

}
