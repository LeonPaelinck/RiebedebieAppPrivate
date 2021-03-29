import { Kind } from './kind.model';

const JsonKinderen = [
  {
    lastName: 'Goethals',
    firstName: 'Zjef',
    birthDate: '2001-05-06'
  },
  {
    lastName: 'Goethals',
    firstName: 'Trees',
    birthDate: '1999-10-04'
  },
  {
    lastName: 'Van Lierde',
    firstName: 'JP',
    birthDate: '2001-08-08'
  }
];
export const KINDEREN: Kind[] = JsonKinderen.map(Kind.fromJSON);