import { Component, Inject, Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ApiService {
    private http: Http;
    private url: string;

    constructor(http: Http, @Inject("API_URL") url: string) {
        this.http = http;
        this.url = url;
    }

    public GetResumeData(id: string): Observable<Response> {
        return this.GetData(this.url + "/api/Candidates/" + id);
    }

    public GetCoverData(guid: string): Observable<Response> {
        return this.GetData(this.url + "/api/CVContents/" + guid);
    }

    private GetData(url: string): Observable<Response> {
        return this.http.get(url);
    }
}