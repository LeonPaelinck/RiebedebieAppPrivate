import { Pipe, PipeTransform } from '@angular/core';
import { Kind } from './kind.model';

@Pipe({
  name: 'kindFilter'
})
export class KindFilterPipe implements PipeTransform {
  transform(kinderen: Kind[], firstName: string): Kind[] {
    if (!firstName || firstName.length === 0) {
      return kinderen;
    }
    return kinderen.filter(rec =>
      rec.firstName.toLowerCase().startsWith(firstName.toLowerCase())
    );
  }
}