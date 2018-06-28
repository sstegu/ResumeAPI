import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'splitString' })
export class SplitStringPipe implements PipeTransform {

    transform(value: string, ...args: any[]): string[] {

        var splitBy = args[0];

        return value.split(splitBy);

    }

}